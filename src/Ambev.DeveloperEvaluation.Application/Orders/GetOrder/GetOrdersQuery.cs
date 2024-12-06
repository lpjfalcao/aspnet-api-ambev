using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<MessageHelper<IEnumerable<GetOrdersResult>>>
    {
    }    
}
