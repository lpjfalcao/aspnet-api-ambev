using SalesManagementSystem.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagementSystem.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid ProductId { get; set; } 
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; } 

        public decimal Discount { get; set; }

        [NotMapped]
        public decimal TotalAmount { get; set; } 

        public Guid OrderId { get; set; } 
        public virtual Order Order { get; set; }

        public decimal CalculateTotalAmount()
        {
            TotalAmount = UnitPrice * Quantity;
            return TotalAmount;
        }

        public void CalculateTotalAmount(decimal discount)
        {
            TotalAmount = (UnitPrice * Quantity) - Discount;
        }
    }
}


