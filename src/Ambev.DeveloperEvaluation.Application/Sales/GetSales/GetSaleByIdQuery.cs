using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSaleByIdQuery : IRequest<MessageHelper<GetSalesResult>>
    {
        public Guid? Id { get; set; }

        public GetSaleByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
