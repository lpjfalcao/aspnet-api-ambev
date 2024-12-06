namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrders
{
    public class GetOrdersResult
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }
        public string Status { get; set; }

        public IEnumerable<GetProductResult> Products { get; set; }
    }
}
