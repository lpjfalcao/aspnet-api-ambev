namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateProductCommand 
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
