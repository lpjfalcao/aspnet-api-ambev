using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesProfile : Profile
    {
        public GetSalesProfile()
        {
            CreateMap<Sale, GetSalesResult>()
                .ForMember(x => x.Status, opt => opt.MapFrom(sale => EnumHelper.GetDescriptionFromStatusValue(sale.Status)));
            CreateMap<Product, GetProductResult>();
        }
    }
}
