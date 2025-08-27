using AcompanhamentoBasquete.Domain.Common;

namespace AcompanhamentoBasquete.Domain.Entities;

public class Jogo : EntidadeBase
{
    public DateTime Data { get; set; }

    public int Pontos { get; set; }
}
