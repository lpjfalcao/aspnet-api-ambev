using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateOrderHandlerTests
    {
        private readonly CreateOrderHandler _handler;
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IOrderService _orderService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public CreateOrderHandlerTests()
        {
            _serviceBase = Substitute.For<IServiceBase<Order>>();
            _mapper = Substitute.For<IMapper>();
            _mediator = Substitute.For<IMediator>();
            _orderService = Substitute.For<IOrderService>();
            _customerRepository = Substitute.For<ICustomerRepository>();
            _orderItemRepository = Substitute.For<IOrderItemRepository>();

            _handler = new CreateOrderHandler(_serviceBase, _mapper, _mediator, _orderService, _customerRepository, _orderItemRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnOk_WhenValidationSucceeds()
        {

            // Arrange
            var orderItems = new List<OrderItemCommand>
            {
                new OrderItemCommand
                {
                    ProductId = new Guid("e2a95dc1-5ca7-4209-91c2-eee42915a170"),
                    Quantity = 100,
                    UnitPrice = 1000
                }
            };

            var command = new CreateOrderCommand
            {
                CustomerId = new Guid("b7290308-8027-4317-ac55-73e8ed126cc6"),
                OrderDate = new DateOnly(2024, 10, 12),
                BranchId = new Guid("f3d8b40e-e2ec-462b-8c7f-af9d35429197"),
                IsCancelled = false,
                OrderItems = orderItems
            };
            var customer = new Customer { Id = new Guid("b7290308-8027-4317-ac55-73e8ed126cc6"), Name = "Teste" };
           
            var newOrder = new Order
            {
                IsCancelled = false,
                CustomerId = new Guid("b7290308-8027-4317-ac55-73e8ed126cc6"),
                BranchId = new Guid("f3d8b40e-e2ec-462b-8c7f-af9d35429197"),
                OrderDate = new DateOnly(2024, 10, 12),
                TotalAmount = 1000,
                Branch  = new Branch
                {
                    Location = "Teste",
                    Name = "Teste"
                },
                Customer = new Customer
                {
                    Email = "email@teste.com",
                    Name = "Teste"
                }
            };

            _customerRepository.GetByCondition(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<Expression<Func<Customer, object>>>())
                .Returns(Task.FromResult(customer));

            _serviceBase.GetByCondition(Arg.Any<Expression<Func<Order, bool>>>(), Arg.Any<Expression<Func<Order, object>>>(), Arg.Any<Expression<Func<Order, object>>>())
                .Returns(Task.FromResult(newOrder));
           
            _mapper.Map<Order>(command).Returns(newOrder);
            _serviceBase.Add(newOrder).Returns(newOrder);
            _serviceBase.Commit().Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            await _serviceBase.Received(1).Commit();
        }

        [Fact]
        public async Task Handle_ShouldReturnBadRequest_WhenValidationFails()
        {
            // Arrange
            var command = new CreateOrderCommand { CustomerId = new Guid("f3d8b40e-e2ec-462b-8c7f-af9d35429197"), OrderItems = new List<OrderItemCommand>() };
            var validationResult = new ValidationResult(new[] { new ValidationFailure("OrderItems", "Cannot be empty") });
            var customer = new Customer { Id = new Guid("f3d8b40e-e2ec-462b-8c7f-af9d35429197"), Orders = new List<Order>() };

            _customerRepository.GetByCondition(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<Expression<Func<Customer, object>>>())
                .Returns(Task.FromResult(customer));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().ContainSingle().Which.ErrorMessage.Should().Be("É necessário informar os items do pedido");
        }
    }
}
