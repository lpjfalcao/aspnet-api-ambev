using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notifications
{
    public class CreateSaleNotificationHandler : INotificationHandler<CreateSaleNotification>
    {
        private readonly ILoggerService _loggerService;

        public CreateSaleNotificationHandler(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public async Task Handle(CreateSaleNotification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _loggerService.LogInfo("Nova venda cadastrada...");
                _loggerService.LogInfo($"Id: {notification.Id}");
                _loggerService.LogInfo($"Número da venda:{notification.Number}");
                _loggerService.LogInfo($"Data da venda: {notification.SaleDate}");
                _loggerService.LogInfo($"Total: {notification.TotalSaleAmount.ToString("C")}");
                _loggerService.LogInfo($"Filial: {notification.Branch}");
            }, cancellationToken);
        }
    }
}
