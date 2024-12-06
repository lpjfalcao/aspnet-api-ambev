using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<MessageHelper<CreateOrderResult>>
    {
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        
        public IEnumerable<CreateOrderItemCommand> OrderItems { get; set; }
    }
}
