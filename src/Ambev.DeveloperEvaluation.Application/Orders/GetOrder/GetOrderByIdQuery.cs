using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrders
{
    public class GetOrderByIdQuery : IRequest<MessageHelper<GetOrdersResult>>
    {
        public Guid? Id { get; set; }

        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
