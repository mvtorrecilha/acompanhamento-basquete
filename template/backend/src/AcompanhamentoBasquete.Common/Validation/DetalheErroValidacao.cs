using FluentValidation.Results;

namespace AcompanhamentoBasquete.Common.Validation;

public class DetalheErroValidacao
{
    public string Erro { get; init; } = string.Empty;
    public string Detalhe { get; init; } = string.Empty;

    public static explicit operator DetalheErroValidacao(ValidationFailure validationFailure)
    {
        return new DetalheErroValidacao
        {
            Detalhe = validationFailure.ErrorMessage,
            Erro = validationFailure.ErrorCode
        };
    }
}
