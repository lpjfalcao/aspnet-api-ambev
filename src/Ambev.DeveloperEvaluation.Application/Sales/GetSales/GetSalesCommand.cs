using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesCommand : IRequest<MessageHelper<IEnumerable<GetSalesResult>>>
    {
        public Guid Id { get; set; }
    }    
}
