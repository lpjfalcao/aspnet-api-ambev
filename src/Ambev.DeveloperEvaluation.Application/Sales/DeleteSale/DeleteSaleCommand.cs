using Ambev.DeveloperEvaluation.Common.Helpers;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleCommand : IRequest<MessageHelper>
    {
        public Guid Id { get; set; }

        public DeleteSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
