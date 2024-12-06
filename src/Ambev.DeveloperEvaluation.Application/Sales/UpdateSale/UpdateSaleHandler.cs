using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notifications;
using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, MessageHelper>
    {
        private readonly IServiceBase<Sale> _serviceBase;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateSaleHandler(IServiceBase<Sale> serviceBase, IMapper mapper, IMediator mediator)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<MessageHelper> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper();
            var validationResult = new ValidationResult();

            try
            {
                var validator = new UpdateSaleValidator();

                validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    throw new DomainException("Ocorreu um ou mais erros durante a validação dos dados");

                var sale = await _serviceBase.GetByCondition(x => x.Id == request.Id);

                if (sale is null)
                    throw new DomainException($"A venda de id {request.Id} não foi encontrada");

                _serviceBase.Update(_mapper.Map<Sale>(request));

                await _serviceBase.Commit();

                await _mediator.Publish(new UpdateSaleNotification
                {
                    Id = request.Id,
                    Branch = request.Branch,
                    Number = request.Number,
                    SaleDate = request.SaleDate,
                    TotalSaleAmount = request.TotalSaleAmount
                });

                message.Ok();
            }
            catch(DomainException ex)
            {
                message.BadRequest(ex, validationResult.Errors);
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
