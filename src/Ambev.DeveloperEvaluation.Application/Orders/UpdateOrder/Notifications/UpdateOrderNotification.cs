using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder.Notifications
{
    public class UpdateOrderNotification : INotification
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }
    }
}
