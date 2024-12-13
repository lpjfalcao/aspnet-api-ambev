using Microsoft.AspNetCore.Builder;

namespace SalesManagementSystem.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
