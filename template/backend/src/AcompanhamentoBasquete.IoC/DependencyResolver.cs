using AcompanhamentoBasquete.IoC.ModuleInitializers;
using Microsoft.AspNetCore.Builder;

namespace AcompanhamentoBasquete.IoC;
public static class DependencyResolver
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        new ApplicationModuleInitializer().Initialize(builder);
        new InfrastructureModuleInitializer().Initialize(builder);
    }
}