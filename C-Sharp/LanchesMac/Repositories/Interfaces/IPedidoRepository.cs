using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces;

public interface IPedidoRepository
{
    void CriarPedido(Pedido pedido);
    Task<IEnumerable<Pedido>> ObtemPedidosRange(int skip, int take);
    Task<IEnumerable<Pedido>> ObtemPedidosRange(string filter, int skip, int take);
    Task<int> ObtemQuantidadePedidos();
    Task<int> ObtemQuantidadePedidos(string filter);
}
