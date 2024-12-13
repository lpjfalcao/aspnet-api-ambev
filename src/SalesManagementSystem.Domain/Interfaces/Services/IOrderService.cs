using SalesManagementSystem.Domain.Entities;

namespace SalesManagementSystem.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        void ApplyDiscount(Order newOrder, Customer customer);
    }
}
