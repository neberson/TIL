using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.ViewModel
{
    public class PaginacaoLanchesViewModel : PaginacaoBase
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public Lanche Lanche { get; set; }
    }
}
