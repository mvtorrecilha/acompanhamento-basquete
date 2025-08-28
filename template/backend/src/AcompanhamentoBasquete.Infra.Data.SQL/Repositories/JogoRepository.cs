using AcompanhamentoBasquete.Domain.Entities;
using AcompanhamentoBasquete.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AcompanhamentoBasquete.Infra.Data.SQL.Repositories;


public class JogoRepository : IJogoRepository
{
    private readonly AppDbContext _context;

    public JogoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Jogo>> ObterTodosOrdenadosPorDataAsync()
    {
        return await _context.Jogos
            .OrderBy(g => g.Data)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Jogo jogo, CancellationToken cancellationToken)
    {
        await _context.Jogos.AddAsync(jogo, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}