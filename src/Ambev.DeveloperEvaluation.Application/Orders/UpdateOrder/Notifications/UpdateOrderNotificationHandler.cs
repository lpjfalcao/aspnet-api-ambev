using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder.Notifications
{
    public class UpdateOrderNotificationHandler : INotificationHandler<UpdateOrderNotification>
    {
        private readonly ILoggerService _loggerService;

        public UpdateOrderNotificationHandler(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task Handle(UpdateOrderNotification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _loggerService.LogInfo("Pedido Atualizado...");
                _loggerService.LogInfo($"Id: {notification.Id}");
                _loggerService.LogInfo($"Data da venda: {notification.OrderDate}");
                _loggerService.LogInfo($"Total: {notification.TotalSaleAmount.ToString("C")}");
                _loggerService.LogInfo($"Filial: {notification.Branch}");
                _loggerService.LogInfo($"Cliente: {notification.CustomerName}");
            }, cancellationToken);
        }
    }
}
