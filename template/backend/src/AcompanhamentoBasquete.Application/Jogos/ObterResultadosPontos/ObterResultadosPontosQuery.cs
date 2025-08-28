using MediatR;

namespace AcompanhamentoBasquete.Application.Jogos.ObterResultadosPontos;

public record ObterResultadosPontosQuery : IRequest<ObterResultadosPontosResult>;