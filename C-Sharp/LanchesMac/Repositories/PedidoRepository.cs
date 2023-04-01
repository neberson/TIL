using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories;
public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
    {
        _appDbContext = appDbContext;
        _carrinhoCompra = carrinhoCompra;
    }

    public void CriarPedido(Pedido pedido)
    {
        pedido.PedidoEnviado = DateTime.Now;
        _appDbContext.Pedidos.Add(pedido);
        _appDbContext.SaveChanges();

        var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

        foreach(var carrinhoItem in carrinhoCompraItens)
        {
            var pedidoDetail = new PedidoDetalhe()
            {
                Quantidade = carrinhoItem.Quantidade,
                LancheId = carrinhoItem.Lanche.LancheId,
                PedidoId = pedido.PedidoId,
                Preco = carrinhoItem.Lanche.Preco
            };

            _appDbContext.PedidoDetalhes.Add(pedidoDetail);
        }
        _appDbContext.SaveChanges();
    }

    public async Task<IEnumerable<Pedido>> ObtemPedidosRange(string filter, int skip, int take)
    {
        var pedidos = await _appDbContext.Pedidos
                                         .Where(p => p.Nome.Contains(filter))
                                         .OrderBy(p => p.Nome)
                                         .AsNoTracking()
                                         .Skip(skip)
                                         .Take(take)
                                         .ToListAsync();
        return pedidos;
    }

    public async Task<IEnumerable<Pedido>> ObtemPedidosRange(int skip, int take)
    {
        var pedidos = await _appDbContext.Pedidos
                                         .OrderBy(p => p.Nome)
                                         .AsNoTracking()
                                         .Skip(skip)
                                         .Take(take)
                                         .ToListAsync();
        return pedidos;
    }

    public async Task<int> ObtemQuantidadePedidos()
    {
        return await _appDbContext.Pedidos.CountAsync();
    }

    public async Task<int> ObtemQuantidadePedidos(string filter)
    {
        return await _appDbContext.Pedidos.Where(pedido => pedido.Nome.Contains(filter)).CountAsync();
    }
}
