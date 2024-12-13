using SalesManagementSystem.Domain.Entities;

namespace SalesManagementSystem.Application.Orders.CreateOrder
{
    public class CreateOrderResult
    {
        public Guid Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public IEnumerable<CreateOrderItemResult> OrderItems { get; set; }
    }

    public class CreateOrderItemResult
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount => CalculateTotalAmount();

        private decimal CalculateTotalAmount()
        {
            return (UnitPrice * Quantity) - Discount;
        }

        public Guid OrderId { get; set; }
    }
}
