﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<Order, CreateOrderResult>();
            CreateMap<OrderItem, CreateOrderItemResult>();
            CreateMap<OrderItemCommand, OrderItem>();                       
        }
    }
}
