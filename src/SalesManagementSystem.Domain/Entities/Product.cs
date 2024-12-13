using SalesManagementSystem.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; } 

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Product()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
