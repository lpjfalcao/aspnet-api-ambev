using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch : BaseEntity
    {
        [Required]
        public string Name { get; set; } 
        public string Location { get; set; } 
        
        public virtual ICollection<Order> Orders { get; set; } 

        public Branch()
        {
            Orders = new List<Order>();
        }
    }
}
