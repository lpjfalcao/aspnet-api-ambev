using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<MessageHelper>
    {
        public Guid Id { get; set; }

        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
