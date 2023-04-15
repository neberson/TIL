using LanchesMac.Context;
using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.Services
{
    public class GraficoVendasServico
    {
        private readonly AppDbContext _appDbContext;

        public GraficoVendasServico(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanchesGrafico = (from pd in _appDbContext.PedidoDetalhes
                                 join l in _appDbContext.Lanches on pd.LancheId equals l.LancheId
                                 where pd.Pedido.PedidoEnviado >= data
                                 group pd by new { pd.LancheId, l.Nome}
                                 into g
                                 select new LancheGrafico
                                {
                                    LancheNome = g.Key.Nome,
                                    LanchesQuantidade = g.Sum(q => q.Quantidade),
                                    LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                                }).ToList();

            return lanchesGrafico;
        }
    }
}
