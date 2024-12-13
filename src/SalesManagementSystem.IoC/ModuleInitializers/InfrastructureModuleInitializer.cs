using SalesManagementSystem.Domain.Interfaces.Repositories;
using SalesManagementSystem.ORM;
using SalesManagementSystem.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SalesManagementSystem.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));        
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
    }
}