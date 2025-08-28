using Microsoft.AspNetCore.Builder;

namespace AcompanhamentoBasquete.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
