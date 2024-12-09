using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class OrderService : IOrderService
    {
        public void ApplyDiscount(Order newOrder, Customer customer)
        {
            var countIdenticalItems = customer.Orders
               .SelectMany(orderCustomer => orderCustomer.OrderItems)
               .Where(orderItem => newOrder.OrderItems.Any(newOrderItem => newOrderItem.ProductId == orderItem.ProductId))
               .Count();

            decimal discount = GetDiscount(countIdenticalItems);

            foreach (var orderItem in newOrder.OrderItems)
            {
                if (customer.Orders
                     .SelectMany(order => order.OrderItems)
                     .Where(customerOrderItem => customerOrderItem.ProductId == orderItem.ProductId)
                     .Any())
                {
                    orderItem.Discount = orderItem.CalculateTotalAmount() * discount;
                    orderItem.CalculateTotalAmount(orderItem.Discount);
                }
            }

            static decimal GetDiscount(int identicalItemsQuantity)
            {
                return identicalItemsQuantity switch
                {
                    int n when n >= 4 && n <= 9 => 0.04M,
                    int n when n >= 10 && n <= 20 => 0.20M,
                    _ => 0,
                };
            }
        }        
    }
}
