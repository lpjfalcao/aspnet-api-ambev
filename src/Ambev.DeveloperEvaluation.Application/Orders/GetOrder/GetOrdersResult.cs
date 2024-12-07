namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrders
{
    public class GetOrdersResult
    {
        public Guid Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public BranchResult Branch { get; set; }
        public CustomerResult Customer { get; set; }
        public IEnumerable<OrderItemResult> OrderItems { get; set; }
    }

    public class BranchResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
       
    }

    public class CustomerResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class ProductResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class OrderItemResult
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }
    }
}
