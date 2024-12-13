using SalesManagementSystem.Application.Sales.CreateSale.Notifications;
using SalesManagementSystem.Common.Helpers;
using SalesManagementSystem.Domain.Entities;
using SalesManagementSystem.Domain.Interfaces.Repositories;
using SalesManagementSystem.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace SalesManagementSystem.Application.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, MessageHelper<CreateOrderResult>>
    {
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IOrderService _orderService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public CreateOrderHandler(IServiceBase<Order> serviceBase,
            IMapper mapper,
            IMediator mediator,
            IOrderService orderService,
            ICustomerRepository customerRepository,
            IOrderItemRepository orderItemRepository)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
            _mediator = mediator;
            _orderService = orderService;
            _customerRepository = customerRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<MessageHelper<CreateOrderResult>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<CreateOrderResult>();
            var validationResult = new ValidationResult();
            Order newOrder = new();

            try
            {
                var validator = new CreateOrderValidator();

                validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    throw new DomainException("Ocorreu um ou mais erros durante a validação dos dados");

                var customer = await _customerRepository.GetByCondition(x => x.Id == request.CustomerId, x => x.Orders);

                foreach (var customerOrder in customer.Orders)
                {
                    customerOrder.OrderItems = (await _orderItemRepository.GetListByCondition(x => x.OrderId == customerOrder.Id)).ToList();
                }

                foreach (var orderItem in request.OrderItems)
                {
                     newOrder = _mapper.Map<Order>(request);
                    
                    _orderService.ApplyDiscount(newOrder, customer);
                }

                newOrder.CalculateTotalAmout();

                var entityCreated = _serviceBase.Add(newOrder);

                await _serviceBase.Commit();

                message.Ok(this._mapper.Map<CreateOrderResult>(entityCreated));

                var order = await _serviceBase.GetByCondition(x => x.Id == entityCreated.Id, x => x.Branch, x => x.Customer);

                await _mediator.Publish(new CreateOrderNotification
                {
                    Id = order.Id,
                    Branch = order.Branch.Name,
                    CustomerName = order.Customer.Name,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    IsCancelled = order.IsCancelled
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
