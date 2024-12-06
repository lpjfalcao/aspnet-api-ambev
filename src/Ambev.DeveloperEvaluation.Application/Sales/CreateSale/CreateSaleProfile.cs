using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using AutoMapper;
using System.ComponentModel;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>();
            CreateMap<Sale, CreateSaleResult>()
                .ForMember(x => x.Status, opt => opt.MapFrom(sale => EnumHelper.GetDescriptionFromStatusValue<SaleStatus>(sale.Status)));
            CreateMap<ProductCommand, Product>();           
        }
       
    }
}
