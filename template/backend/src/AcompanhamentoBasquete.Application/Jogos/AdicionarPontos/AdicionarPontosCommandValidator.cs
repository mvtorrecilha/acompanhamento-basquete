using FluentValidation;

namespace AcompanhamentoBasquete.Application.Jogos.AdicionarPontos;

public class AdicionarPontosCommandValidator : AbstractValidator<AdicionarPontosCommand>
{
    public AdicionarPontosCommandValidator()
    {
        RuleFor(x => x.Data)
            .NotEmpty().WithMessage("A data é obrigatória.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data não pode ser maior que hoje.");

        RuleFor(x => x.Pontos)
            .GreaterThan(0).WithMessage("Os pontos devem ser maiores que zero.");
    }
}