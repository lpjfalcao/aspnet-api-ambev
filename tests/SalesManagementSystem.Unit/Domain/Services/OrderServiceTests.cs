using SalesManagementSystem.Domain.Entities;
using SalesManagementSystem.Domain.Services;
using Xunit;

namespace SalesManagementSystem.Unit.Domain.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public void ApplyDiscount_ShouldThrowDomainException_WhenIdenticalItemsExceedLimit()
        {
            // Arrange
            var orderService = new OrderService();
            var newOrder = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 1 }
                }
            };
            var customer = new Customer
            {
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 20 },
                            new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 1 },
                        }
                    }
                }
            };

            // Act & Assert
            Assert.Throws<DomainException>(() => orderService.ApplyDiscount(newOrder, customer));
        }

        [Fact]
        public void ApplyDiscount_ShouldApplyDiscount_WhenIdenticalItemsWithinLimit()
        {
            // Arrange
            var orderService = new OrderService();
            var newOrder = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 1, UnitPrice = 1000 },
                }
            };
            var customer = new Customer
            {
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 5 }
                        }
                    }
                }
            };

            // Act
            orderService.ApplyDiscount(newOrder, customer);

            // Assert
            Assert.Equal(40, newOrder.OrderItems.First().Discount);
        }
    }
}
