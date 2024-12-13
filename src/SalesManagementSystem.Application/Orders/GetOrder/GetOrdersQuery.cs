using SalesManagementSystem.Common.Helpers;
using MediatR;

namespace SalesManagementSystem.Application.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<MessageHelper<IEnumerable<GetOrdersResult>>>
    {
    }    
}
