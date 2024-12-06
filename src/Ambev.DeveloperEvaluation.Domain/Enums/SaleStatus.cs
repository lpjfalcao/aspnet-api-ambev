using System.ComponentModel;

namespace Ambev.DeveloperEvaluation.Domain.Enums
{
    public enum OrderStatus
    {
        [Description("Não Cancelado")]
        NotCancelled = 1,

        [Description("Cancelado")]
        Cancelled
    }
}
