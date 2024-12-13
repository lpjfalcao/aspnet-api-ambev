using SalesManagementSystem.Common.Helpers;
using MediatR;

namespace SalesManagementSystem.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<MessageHelper<CreateOrderResult>>
    {
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateOnly OrderDate { get; set; }
        public bool IsCancelled { get; set; }
        
        public IEnumerable<OrderItemCommand> OrderItems { get; set; }
    }

    public class OrderItemCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
