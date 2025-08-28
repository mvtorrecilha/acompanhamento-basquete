using AcompanhamentoBasquete.Domain.Entities;
using AcompanhamentoBasquete.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AcompanhamentoBasquete.Application.Jogos.AdicionarPontos;

public class AdicionarPontosCommandHandler : IRequestHandler<AdicionarPontosCommand, AdicionarPontosResult>
{
    private readonly IJogoRepository _jogoRepository;
    private readonly ILogger<AdicionarPontosCommandHandler> _logger;


    public AdicionarPontosCommandHandler(
        IJogoRepository jogoRepository,
        ILogger<AdicionarPontosCommandHandler> logger
        )
    {
        _jogoRepository = jogoRepository;
        _logger = logger;
    }

    public async Task<AdicionarPontosResult> Handle(AdicionarPontosCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Handler {AdicionarPontosCommandHandler} acionado para adicioanar pontos na data {Data}",
            nameof(AdicionarPontosCommandHandler),
            request.Data
        );

        Jogo jogo = new()
        {
            Id = Guid.NewGuid(),
            Data = request.Data,
            Pontos = request.Pontos
        };

        await _jogoRepository.AdicionarAsync(jogo, cancellationToken);

        _logger.LogInformation("pontos adicionado com sucesso.");

        return AdicionarPontosResult.ResultadoSucesso();    
    }
}