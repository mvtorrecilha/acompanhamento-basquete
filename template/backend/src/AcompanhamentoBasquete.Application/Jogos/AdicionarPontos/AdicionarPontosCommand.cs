using MediatR;

namespace AcompanhamentoBasquete.Application.Jogos.AdicionarPontos;

public class AdicionarPontosCommand : IRequest<AdicionarPontosResult>
{
    public DateTime Data { get; set; }

    public int Pontos { get; set; }
}