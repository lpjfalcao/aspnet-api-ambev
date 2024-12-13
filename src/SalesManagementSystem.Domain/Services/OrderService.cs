using SalesManagementSystem.Domain.Entities;
using SalesManagementSystem.Domain.Interfaces.Services;

namespace SalesManagementSystem.Domain.Services
{
    public class OrderService : IOrderService
    {
        public void ApplyDiscount(Order newOrder, Customer customer)
        {
            const string message = "Não é possível efetuar a venda de mais do que 20 itens para o produto selecionado";

            var countIdenticalItemsAtDatabase = customer.Orders
               .SelectMany(orderCustomer => orderCustomer.OrderItems)
               .Where(orderItem => newOrder.OrderItems.Any(newOrderItem => newOrderItem.ProductId == orderItem.ProductId))
               .Sum(x => x.Quantity);

            if (countIdenticalItemsAtDatabase > 20)
                throw new DomainException(message);

            decimal discount;

            foreach (var orderItem in newOrder.OrderItems)
            {
                if (orderItem.Quantity > 20)
                    throw new DomainException(message);

                if (customer.Orders
                     .SelectMany(order => order.OrderItems)
                     .Where(customerOrderItem => customerOrderItem.ProductId == orderItem.ProductId)
                     .Any())
                {
                    discount = GetDiscount(countIdenticalItemsAtDatabase);
                    orderItem.Discount = orderItem.CalculateTotalAmount() * discount;
                    orderItem.CalculateTotalAmount(orderItem.Discount);
                }
                else
                {
                    discount = GetDiscount(orderItem.Quantity);
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
