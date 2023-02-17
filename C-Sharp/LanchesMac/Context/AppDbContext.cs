using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    #region "Mapeamento das classes do sistema para tabelas do banco"
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    #endregion
}
