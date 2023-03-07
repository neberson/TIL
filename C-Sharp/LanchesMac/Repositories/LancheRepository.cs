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
}
