using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories;
public class LancheRepository : ILanchesRepository
{
    private readonly AppDbContext _context;
    public LancheRepository(AppDbContext contexto)
    {
        _context = contexto;
    }

    public IEnumerable<Lanche> Lanches => _context.Lanches.Include(lanche => lanche.Categoria);

    public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
                                                            .Where(lanche => lanche.IsLanchePreferido == true)
                                                            .Include(lanche=> lanche.Categoria);

    public Lanche GetLancheById(int lancheId)
    {
        return _context.Lanches
                       .Include(lanche => lanche.Categoria)
                       .FirstOrDefault(lanche => lanche.LancheId == lancheId);
    }


    public async Task<int> ObtemQuantidadeLanches()
    {
        return await _context.Lanches.CountAsync();
    }

    public async Task<int> ObtemQuantidadeLanches(string filter)
    {
        return await _context.Lanches.Where(pedido => pedido.Nome.Contains(filter)).CountAsync();
    }

    public async Task<IEnumerable<Lanche>> ObtemLanchesRange(int skip, int take)
    {
        var lanches = await _context.Lanches
                                         .Include(lanche => lanche.Categoria)
                                         .OrderBy(p => p.Nome)
                                         .AsNoTracking()
                                         .Skip(skip)
                                         .Take(take)
                                         .ToListAsync();
        return lanches;
    }

    public async Task<IEnumerable<Lanche>> ObtemLanchesRange(string filter, int skip, int take)
    {
        var lanches = await _context.Lanches
                                         .Include(lanche => lanche.Categoria)
                                         .Where(p => p.Nome.Contains(filter))
                                         .OrderBy(p => p.Nome)
                                         .AsNoTracking()
                                         .Skip(skip)
                                         .Take(take)
                                         .ToListAsync();
        return lanches;
    }
}
