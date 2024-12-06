using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<MessageHelper>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }

        public UpdateSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
