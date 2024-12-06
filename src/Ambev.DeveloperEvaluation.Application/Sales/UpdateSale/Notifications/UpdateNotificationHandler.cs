using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notifications
{
    public class UpdateNotificationHandler : INotificationHandler<UpdateSaleNotification>
    {
        private readonly ILoggerService _loggerService;

        public UpdateNotificationHandler(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public Task Handle(UpdateSaleNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _loggerService.LogInfo("Venda Atualizada...");
                _loggerService.LogInfo($"Id: {notification.Id}");
                _loggerService.LogInfo($"Número da venda:{notification.Number}");
                _loggerService.LogInfo($"Data da venda: {notification.SaleDate}");
                _loggerService.LogInfo($"Total: {notification.TotalSaleAmount.ToString("C")}");
                _loggerService.LogInfo($"Filial: {notification.Branch}");
            });
        }
    }
}
