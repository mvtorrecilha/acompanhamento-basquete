using AcompanhamentoBasquete.Domain.Repositories;
using AcompanhamentoBasquete.Infra.Data.SQL;
using AcompanhamentoBasquete.Infra.Data.SQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AcompanhamentoBasquete.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<AppDbContext>());
        builder.Services.AddScoped<IJogoRepository, JogoRepository>();
    }
}