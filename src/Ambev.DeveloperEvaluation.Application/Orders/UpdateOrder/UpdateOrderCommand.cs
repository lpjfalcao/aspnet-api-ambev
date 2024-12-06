using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<MessageHelper>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }

        public UpdateOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
