using Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder.Notifications;
using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, MessageHelper>
    {
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateOrderHandler(IServiceBase<Order> serviceBase, IMapper mapper, IMediator mediator)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<MessageHelper> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper();
            var validationResult = new ValidationResult();

            try
            {
                var validator = new UpdateOrderValidator();

                validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    throw new DomainException("Ocorreu um ou mais erros durante a validação dos dados");

                var order = await _serviceBase.GetByCondition(x => x.Id == request.Id, x => x.Branch, x => x.Customer) ??
                    throw new DomainException($"A venda de id {request.Id} não foi encontrada"); ;

                _serviceBase.Update(_mapper.Map<Order>(request));

                await _serviceBase.Commit();

                await _mediator.Publish(new UpdateOrderNotification
                {
                    Id = order.Id,
                    Branch = order.Branch.Name,
                    CustomerName = order.Customer.Name,
                    OrderDate = order.OrderDate,
                    TotalSaleAmount = order.TotalAmount,
                    IsCancelled = order.IsCancelled
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
