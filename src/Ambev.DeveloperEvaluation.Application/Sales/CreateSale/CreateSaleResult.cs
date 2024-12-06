namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }
        public string Status { get; set; }
    }
}
