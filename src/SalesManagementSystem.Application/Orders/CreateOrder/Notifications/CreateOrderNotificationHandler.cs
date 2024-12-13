using SalesManagementSystem.Application.Sales.CreateSale.Notifications;
using SalesManagementSystem.Domain.Interfaces.Services;
using MediatR;

namespace SalesManagementSystem.Application.Orderss.CreateOrder.Notifications
{
    public class CreateOrderNotificationHandler : INotificationHandler<CreateOrderNotification>
    {
        private readonly ILoggerService _loggerService;

        public CreateOrderNotificationHandler(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public async Task Handle(CreateOrderNotification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _loggerService.LogInfo("Nova venda cadastrada...");
                _loggerService.LogInfo($"Id: {notification.Id}");
                _loggerService.LogInfo($"Cliente:{notification.CustomerName}");
                _loggerService.LogInfo($"Data da venda: {notification.OrderDate}");
                _loggerService.LogInfo($"Total: {notification.TotalAmount.ToString("C")}");
                _loggerService.LogInfo($"Filial: {notification.Branch}");
            }, cancellationToken);
        }
    }
}
