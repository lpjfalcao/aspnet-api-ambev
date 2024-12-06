using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int Number { get; set; }
        public DateOnly SaleDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string? Branch { get; set; }
        public SaleStatus Status { get; set; }

        public ICollection<Product> Products { get; set; }

        public Sale()
        {
            Status = SaleStatus.NotCancelled;
        }
    }
}
