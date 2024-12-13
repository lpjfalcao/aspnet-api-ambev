using SalesManagementSystem.Common.Helpers;
using MediatR;
using System.Text.Json.Serialization;

namespace SalesManagementSystem.Application.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<MessageHelper>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }    
}
