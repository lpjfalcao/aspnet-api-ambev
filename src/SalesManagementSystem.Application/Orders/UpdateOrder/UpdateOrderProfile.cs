using SalesManagementSystem.Domain.Entities;
using AutoMapper;

namespace SalesManagementSystem.Application.Orders.UpdateOrder
{
    public class UpdateOrderProfile : Profile
    {
        public UpdateOrderProfile()
        {
            CreateMap<UpdateOrderCommand, Order>();
        }
    }
}
