namespace AcompanhamentoBasquete.Application.Jogos.ObterResultadosPontos;

public record ObterResultadosPontosResult(
    DateTime DataPrimeiroJogo,
    DateTime DataUltimoJogo,
    int TotalJogos,
    int TotalPontos,
    double MediaPontos,
    int MaiorPontuacao,
    int MenorPontuacao,
    int QuantidadeRecordes
);