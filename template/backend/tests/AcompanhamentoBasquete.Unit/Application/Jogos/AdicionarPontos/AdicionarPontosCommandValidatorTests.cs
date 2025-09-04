using AcompanhamentoBasquete.Application.Jogos.AdicionarPontos;
using Bogus;
using FluentValidation.TestHelper;

namespace AcompanhamentoBasquete.Unit.Application.Jogos.AdicionarPontos;

public class AdicionarPontosCommandValidatorTests
{
    private readonly Faker _faker = new Faker();
    private readonly AdicionarPontosCommandValidator _validator;

    public AdicionarPontosCommandValidatorTests()
    {
        _validator = new AdicionarPontosCommandValidator();
    }

    [Fact(DisplayName = "Dado dados válidos Quando validar a entrada de pontos Então deve ocorrer com sucesso")]
    public void Deve_Validar_Sucesso()
    {
        // Given
        var command = new AdicionarPontosCommand
        {
            Data = DateTime.UtcNow.AddDays(-1),
            Pontos = _faker.Random.Int(1, 100)
        };

        // When
        var result = _validator.TestValidate(command);

        // Then
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Dado uma data futura Quando validar Então deve falhar")]
    public void Deve_Falhar_Quando_Data_Futura()
    {
        // Given
        var command = new AdicionarPontosCommand
        {
            Data = DateTime.UtcNow.AddDays(1),
            Pontos = 10
        };

        // When
        var result = _validator.TestValidate(command);

        // Then
        result.ShouldHaveValidationErrorFor(c => c.Data)
              .WithErrorMessage("A data não pode ser maior que hoje.");
    }

    [Fact(DisplayName = "Dado pontos negativos Quando validar Então deve falhar")]
    public void Deve_Falhar_Quando_Pontos_Negativos()
    {
        // Given
        var command = new AdicionarPontosCommand
        {
            Data = DateTime.UtcNow,
            Pontos = -5
        };

        // When
        var result = _validator.TestValidate(command);

        // Then
        result.ShouldHaveValidationErrorFor(c => c.Pontos)
              .WithErrorMessage("Os pontos devem ser zero ou maiores que zero.");
    }
}