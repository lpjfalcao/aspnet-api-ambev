using SalesManagementSystem.Domain.Interfaces.Services;
using SalesManagementSystem.Domain.Services;
using SalesManagementSystem.ORM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SalesManagementSystem.IoC.ModuleInitializers
{
    public class DomainModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}
