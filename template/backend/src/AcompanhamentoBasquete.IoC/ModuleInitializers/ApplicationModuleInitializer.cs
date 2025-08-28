using AcompanhamentoBasquete.Application;
using AcompanhamentoBasquete.Common.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AcompanhamentoBasquete.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationLayer).Assembly);
        });

        builder.Services.AddValidatorsFromAssembly(typeof(ApplicationLayer).Assembly);

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}