using AcompanhamentoBasquete.Application.Jogos.AdicionarPontos;
using AcompanhamentoBasquete.Domain.Entities;
using AcompanhamentoBasquete.Domain.Repositories;
using Bogus;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace AcompanhamentoBasquete.Unit.Application.Jogos.AdicionarPontos;

public class AdicionarPontosCommandHandlerTests
{
    private readonly IJogoRepository _jogoRepository;
    private readonly ILogger<AdicionarPontosCommandHandler> _logger;
    private readonly Faker _faker = new();

    public AdicionarPontosCommandHandlerTests()
    {
        _jogoRepository = Substitute.For<IJogoRepository>();
        _logger = Substitute.For<ILogger<AdicionarPontosCommandHandler>>();
    }

    [Fact(DisplayName = "Dado dados válidos Quando adicionar jogo Então deve ser adicionado com sucesso")]
    public async Task Handle_Deve_Adicionar_Jogo_Com_Sucesso()
    {
        // Given
        var adicionarPontosCommand = new AdicionarPontosCommand
        {
            Data = DateTime.UtcNow.AddDays(-1),
            Pontos = _faker.Random.Int(1, 100)
        };

        // When
        var handler = new AdicionarPontosCommandHandler(_jogoRepository, _logger);

        var result = await handler.Handle(adicionarPontosCommand, CancellationToken.None);

        // Then
        await _jogoRepository.Received(1).AdicionarAsync(Arg.Is<Jogo>(j =>
            j.Data == adicionarPontosCommand.Data && j.Pontos == adicionarPontosCommand.Pontos
        ), Arg.Any<CancellationToken>());

        Assert.True(result.Successo);
    }
}