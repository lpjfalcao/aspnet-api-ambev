using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using Ambev.DeveloperEvaluation.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers
{
    public class DomainModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
        }
    }
}
