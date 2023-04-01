using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.ViewModel
{
    public class PaginacaoPedidosViewModel
    {
        public IEnumerable<Pedido> Pedidos { get; set; }
        public Pedido Pedido { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int QuantidadePedidos { get; set; }
        public int TotalPages => (int)Math.Ceiling(QuantidadePedidos/(double)PageSize);
    }
}
