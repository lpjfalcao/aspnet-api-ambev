using System.ComponentModel;

namespace SalesManagementSystem.Domain.Enums
{
    public enum OrderStatus
    {
        [Description("Não Cancelado")]
        NotCancelled = 1,

        [Description("Cancelado")]
        Cancelled
    }
}
