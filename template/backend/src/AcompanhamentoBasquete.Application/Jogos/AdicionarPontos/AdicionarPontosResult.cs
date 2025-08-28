namespace AcompanhamentoBasquete.Application.Jogos.AdicionarPontos;

public class AdicionarPontosResult
{
    public bool Successo { get; set; }

    public static AdicionarPontosResult ResultadoSucesso() => new() { Successo = true };

    public static AdicionarPontosResult ResultadoFalha() => new() { Successo = false };
}
