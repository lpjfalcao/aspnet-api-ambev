using SalesManagementSystem.Domain.Entities;
using AutoMapper;

namespace SalesManagementSystem.Application.Orders.GetOrders
{
    public class GetOrdersProfile : Profile
    {
        public GetOrdersProfile()
        {
            CreateMap<Order, GetOrdersResult>();
            CreateMap<Product, ProductResult>();
            CreateMap<Customer, CustomerResult>();
            CreateMap<Branch, BranchResult>();
            CreateMap<OrderItem, OrderItemResult>();
        }
    }
}
