using AcompanhamentoBasquete.Common.Validation;

namespace AcompanhamentoBasquete.API.Common;

public class ApiResponse
{
    public bool Successo { get; set; }

    public string Mensagem { get; set; } = string.Empty;

    public IEnumerable<DetalheErroValidacao> Erros { get; set; } = [];
}
