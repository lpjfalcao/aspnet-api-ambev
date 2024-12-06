using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notifications;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orderss.CreateOrder.Notifications
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
                _loggerService.LogInfo($"Número da venda:{notification.Number}");
                _loggerService.LogInfo($"Data da venda: {notification.OrderDate}");
                _loggerService.LogInfo($"Total: {notification.TotalAmount.ToString("C")}");
                _loggerService.LogInfo($"Filial: {notification.Branch}");
            }, cancellationToken);
        }
    }
}
