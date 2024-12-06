using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notifications
{
    public class CreateSaleNotification : INotification
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }
    }
}
