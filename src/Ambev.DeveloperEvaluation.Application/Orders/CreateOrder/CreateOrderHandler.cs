using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notifications;
using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, MessageHelper<CreateOrderResult>>
    {
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateOrderHandler(IServiceBase<Order> serviceBase, IMapper mapper, IMediator mediator)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<MessageHelper<CreateOrderResult>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<CreateOrderResult>();
            var validationResult = new ValidationResult();

            try
            {
                var validator = new CreateOrderValidator();

                validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    throw new DomainException("Ocorreu um ou mais erros durante a validação dos dados");

                var entityCreated = _serviceBase.Add(_mapper.Map<Order>(request));

                await _serviceBase.Commit();

                message.Ok(this._mapper.Map<CreateOrderResult>(entityCreated));

                await _mediator.Publish(new CreateOrderNotification
                {
                    Id = entityCreated.Id,
                    Branch = entityCreated.Branch.Name,
                    OrderDate = entityCreated.OrderDate,
                    TotalAmount = entityCreated.TotalAmount,
                    IsCancelled = entityCreated.IsCancelled
                });
            }
            catch (DomainException ex)
            {
                message.BadRequest(ex, validationResult.Errors);
            }
            catch (Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
