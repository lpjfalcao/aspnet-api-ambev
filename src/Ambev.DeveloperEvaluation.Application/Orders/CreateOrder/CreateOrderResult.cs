using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderResult
    {
        public Guid Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
