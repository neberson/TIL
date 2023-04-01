using LanchesMac.Models;
namespace LanchesMac.Repositories.Interfaces;
public interface ILanchesRepository
{
    IEnumerable<Lanche> Lanches { get; }
    IEnumerable<Lanche> LanchesPreferidos { get; }
    Lanche GetLancheById(int lancheId);
    Task<IEnumerable<Lanche>> ObtemLanchesRange(int skip, int take);
    Task<IEnumerable<Lanche>> ObtemLanchesRange(string filter, int skip, int take);
    Task<int> ObtemQuantidadeLanches();
    Task<int> ObtemQuantidadeLanches(string filter);

}
