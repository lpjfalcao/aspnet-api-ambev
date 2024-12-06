using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid ProductId { get; set; } 
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; } 

        public decimal Discount { get; set; } 

        public decimal TotalAmount => CalculateTotalAmount(); 

        private decimal CalculateTotalAmount()
        {
            return (UnitPrice * Quantity) - Discount;
        }

        public Guid OrderId { get; set; } 
        public virtual Order Order { get; set; } 
    }
}
