using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        void ApplyDiscount(Order newOrder, Customer customer);
    }
}
