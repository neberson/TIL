using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.ViewModel
{
    public class PaginacaoPedidosViewModel : PaginacaoBase
    {
        public IEnumerable<Pedido> Pedidos { get; set; }
        public Pedido Pedido { get; set; }
    }
}
