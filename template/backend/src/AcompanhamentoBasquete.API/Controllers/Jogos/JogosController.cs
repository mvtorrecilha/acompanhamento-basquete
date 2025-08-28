using AcompanhamentoBasquete.API.Common;
using AcompanhamentoBasquete.API.Controllers.Jogos.AdicionarPontos;
using AcompanhamentoBasquete.Application.Jogos.AdicionarPontos;
using AcompanhamentoBasquete.Application.Jogos.ObterResultadosPontos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcompanhamentoBasquete.API.Controllers.Jogos;

[Route("api/[controller]")]
public class JogosController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<JogosController> _logger;

    public JogosController(IMediator mediator, ILogger<JogosController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("resultados")]
    [ProducesResponseType(typeof(ApiResponseWithData<ObterResultadosPontosResult>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterResultadosAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("O controller {JogosController} foi acionado para obter resultados dos pontos lançados.",
          nameof(JogosController));

        var resultado = await _mediator.Send(new ObterResultadosPontosQuery(), cancellationToken);

        return Ok(new ApiResponseWithData<ObterResultadosPontosResult>
        {
            Successo = true,
            Mensagem = "Resultados dos jogos disputados.",
            Data = resultado
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarPontosAsync([FromBody] AdicionarPontosRequest requisicao, CancellationToken cancellationToken)
    {
        _logger.LogInformation("O controller {JogosController} foi acionado para processar {AdicionarPontosRequest}",
           nameof(JogosController), nameof(AdicionarPontosRequest));

        var adicionarPontosCommand = new AdicionarPontosCommand
        {
            Data = requisicao.Data,
            Pontos = requisicao.Pontos
        };

        var resultado = await _mediator.Send(adicionarPontosCommand, cancellationToken);

        return Created(string.Empty, new ApiResponse
        {
            Successo = true,
            Mensagem = "pontos lançado com sucesso.",
        });
    }
}
