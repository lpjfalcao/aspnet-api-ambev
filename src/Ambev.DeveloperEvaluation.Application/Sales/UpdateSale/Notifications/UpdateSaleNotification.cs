using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notifications
{
    public class UpdateSaleNotification : INotification
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }
    }
}
