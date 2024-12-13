using SalesManagementSystem.Common.Helpers;
using MediatR;

namespace SalesManagementSystem.Application.Orders.DeleteOrder
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
