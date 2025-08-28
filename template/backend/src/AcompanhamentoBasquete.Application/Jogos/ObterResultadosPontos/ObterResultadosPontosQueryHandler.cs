using AcompanhamentoBasquete.Domain.Entities;
using AcompanhamentoBasquete.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AcompanhamentoBasquete.Application.Jogos.ObterResultadosPontos;

public class ObterResultadosPontosQueryHandler : IRequestHandler<ObterResultadosPontosQuery, ObterResultadosPontosResult>
{
    private readonly IJogoRepository _jogoRepository;
    private readonly ILogger<ObterResultadosPontosQueryHandler> _logger;

    public ObterResultadosPontosQueryHandler(
        IJogoRepository jogoRepository,
        ILogger<ObterResultadosPontosQueryHandler> logger)
    {
        _jogoRepository = jogoRepository;
        _logger = logger;
    }


    public async Task<ObterResultadosPontosResult> Handle(ObterResultadosPontosQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Obtendo resultados dos pontos");

        IReadOnlyList<Jogo> jogos = await _jogoRepository.ObterTodosOrdenadosPorDataAsync();

        if (!jogos.Any())
            return null!;

        _logger.LogInformation("Calculando quantidade de vezes que bateu o próprio recorde.");
        int quantidadeRecordes = CalcularRecordes(jogos);

        _logger.LogInformation("Retornando os resultados dos pontos");

        return new ObterResultadosPontosResult(
            DataPrimeiroJogo: jogos.First().Data,
            DataUltimoJogo: jogos.Last().Data,
            TotalJogos: jogos.Count,
            TotalPontos: jogos.Sum(g => g.Pontos),
            MediaPontos: jogos.Average(g => g.Pontos),
            MaiorPontuacao: jogos.Max(g => g.Pontos),
            MenorPontuacao: jogos.Min(g => g.Pontos),
            QuantidadeRecordes: quantidadeRecordes
        );
    }

    private static int CalcularRecordes(IReadOnlyList<Jogo> jogos)
    {
        int recordes = 0;
        int maiorAnterior = int.MinValue;

        foreach (var jogo in jogos)
        {
            if (jogo.Pontos > maiorAnterior)
            {
                if (maiorAnterior != int.MinValue)
                    recordes++;

                maiorAnterior = jogo.Pontos;
            }
        }

        return recordes;
    }
}
