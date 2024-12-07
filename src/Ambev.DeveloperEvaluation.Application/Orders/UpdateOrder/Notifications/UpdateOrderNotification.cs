using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder.Notifications
{
    public class UpdateOrderNotification : INotification
    {
        public Guid Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }
        public bool IsCancelled { get; set; }
        public string CustomerName { get; set; }
    }
}
