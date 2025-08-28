using AcompanhamentoBasquete.Domain.Entities;

namespace AcompanhamentoBasquete.Domain.Repositories;

public interface IJogoRepository
{
    Task<IReadOnlyList<Jogo>> ObterTodosOrdenadosPorDataAsync();

    Task AdicionarAsync(Jogo jogo, CancellationToken cancellationToken);
}
