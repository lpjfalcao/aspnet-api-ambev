using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<MessageHelper<CreateSaleResult>>
    {
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }

        public IEnumerable<ProductCommand> Products { get; set; }
    }
}
