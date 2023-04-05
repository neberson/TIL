using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.ViewModel
{
    public class PedidoLancheViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
