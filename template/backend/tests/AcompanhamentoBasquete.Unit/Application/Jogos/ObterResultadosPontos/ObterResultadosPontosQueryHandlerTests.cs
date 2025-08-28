using AcompanhamentoBasquete.Application.Jogos.ObterResultadosPontos;
using AcompanhamentoBasquete.Domain.Entities;
using AcompanhamentoBasquete.Domain.Repositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace AcompanhamentoBasquete.Unit.Application.Jogos.ObterResultadosPontos;

public class ObterResultadosPontosQueryHandlerTests
{
    private readonly IJogoRepository _jogoRepository;
    private readonly ILogger<ObterResultadosPontosQueryHandler> _logger;

    public ObterResultadosPontosQueryHandlerTests()
    {
        _jogoRepository = Substitute.For<IJogoRepository>();
        _logger = Substitute.For<ILogger<ObterResultadosPontosQueryHandler>>();
    }

    [Fact(DisplayName = "Dado dados válidos Quando executar o handle Então deve retornar resultados corretos")]
    public async Task Handle_Deve_Retornar_Resultados_Corretos()
    {
        // Given
        var jogos = new List<Jogo>
        {
            new() { Data = DateTime.UtcNow.AddDays(-9), Pontos = 10 },
            new() { Data = DateTime.UtcNow.AddDays(-8), Pontos = 20 },
            new() { Data = DateTime.UtcNow.AddDays(-7), Pontos = 16 },
            new() { Data = DateTime.UtcNow.AddDays(-6), Pontos = 18 },
            new() { Data = DateTime.UtcNow.AddDays(-5), Pontos = 12 },
            new() { Data = DateTime.UtcNow.AddDays(-4), Pontos = 24 },
            new() { Data = DateTime.UtcNow.AddDays(-3), Pontos = 20 },
            new() { Data = DateTime.UtcNow.AddDays(-2), Pontos = 24 },
            new() { Data = DateTime.UtcNow.AddDays(-1), Pontos = 16 },
        };

        int QuantidadeRecordesEsperado = 2;

        _jogoRepository.ObterTodosOrdenadosPorDataAsync().Returns(jogos);

        var handler = new ObterResultadosPontosQueryHandler(_jogoRepository, _logger);
        var query = new ObterResultadosPontosQuery();

        // When
        var result = await handler.Handle(query, CancellationToken.None);

        // Then
        Assert.NotNull(result);
        Assert.Equal(jogos.First().Data, result.DataPrimeiroJogo);
        Assert.Equal(jogos.Last().Data, result.DataUltimoJogo);
        Assert.Equal(jogos.Count, result.TotalJogos);
        Assert.Equal(jogos.Sum(j => j.Pontos), result.TotalPontos);
        Assert.Equal(jogos.Average(j => j.Pontos), result.MediaPontos);
        Assert.Equal(jogos.Max(j => j.Pontos), result.MaiorPontuacao);
        Assert.Equal(jogos.Min(j => j.Pontos), result.MenorPontuacao);
        Assert.Equal(QuantidadeRecordesEsperado, result.QuantidadeRecordes);

        _logger.Received().Log(
            Arg.Any<LogLevel>(),
            Arg.Any<EventId>(),
            Arg.Any<object>(),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception, string>>()
        );
    }

    [Fact(DisplayName = "Dado que não existam jogos Quando executar o handle Então deve retornar null")]
    public async Task Handle_Quando_Nao_Ha_Jogos_Deve_Retornar_Null()
    {
        // Given
        _jogoRepository.ObterTodosOrdenadosPorDataAsync().Returns(new List<Jogo>());
        var handler = new ObterResultadosPontosQueryHandler(_jogoRepository, _logger);
        var query = new ObterResultadosPontosQuery();

        // When
        var result = await handler.Handle(query, CancellationToken.None);

        // Then
        Assert.Null(result);
        _logger.Received().Log(
            Arg.Any<LogLevel>(),
            Arg.Any<EventId>(),
            Arg.Any<object>(),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception, string>>()
        );
    }
}