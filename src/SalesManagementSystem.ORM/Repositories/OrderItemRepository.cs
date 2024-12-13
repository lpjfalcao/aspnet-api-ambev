using SalesManagementSystem.Domain.Entities;
using SalesManagementSystem.Domain.Interfaces.Repositories;

namespace SalesManagementSystem.ORM.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DefaultContext context) : base(context)
        {
        }
    }
}
