using SalesManagementSystem.Domain.Common;

namespace SalesManagementSystem.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateOnly OrderDate { get; set; } 
        public Guid CustomerId { get; set; } 
        public virtual Customer Customer { get; set; } 
        public decimal TotalAmount { get; set; } 
        public Guid BranchId { get; set; } 
        public virtual Branch Branch { get; set; } 
        public virtual ICollection<OrderItem> OrderItems { get; set; } 

        public bool IsCancelled { get; set; } 

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public void CalculateTotalAmout()
        {
            TotalAmount = OrderItems.Sum(x => x.TotalAmount);
        }
    }
}
