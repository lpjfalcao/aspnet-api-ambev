using SalesManagementSystem.Domain.Common;

namespace SalesManagementSystem.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } 

        public string Email { get; set; } 

        public virtual ICollection<Order> Orders { get; set; } 

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
