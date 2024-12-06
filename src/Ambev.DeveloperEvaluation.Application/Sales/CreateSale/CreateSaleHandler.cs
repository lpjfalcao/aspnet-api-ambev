using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notifications;
using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, MessageHelper<CreateSaleResult>>
    {
        private readonly IServiceBase<Sale> _serviceBase;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateSaleHandler(IServiceBase<Sale> serviceBase, IMapper mapper, IMediator mediator)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<MessageHelper<CreateSaleResult>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<CreateSaleResult>();
            var validationResult = new ValidationResult();

            try
            {
                var validator = new CreateSaleValidator();
                
                validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    throw new DomainException("Ocorreu um ou mais erros durante a validação dos dados");


                var entityCreated = _serviceBase.Add(_mapper.Map<Sale>(request));

                await _serviceBase.Commit();

                message.Ok(this._mapper.Map<CreateSaleResult>(entityCreated));

                await _mediator.Publish(new CreateSaleNotification
                {
                    Id = entityCreated.Id,
                    Branch = entityCreated.Branch,
                    Number = entityCreated.Number,
                    SaleDate = entityCreated.SaleDate,
                    TotalSaleAmount = entityCreated.TotalSaleAmount
                });
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
