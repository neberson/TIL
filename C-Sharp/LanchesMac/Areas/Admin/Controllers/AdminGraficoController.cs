using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace LanchesMac.Areas.Admin.Controllers
{
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasServico _graficoVendasServico;

        public AdminGraficoController(GraficoVendasServico graficoVendasServico)
        {
            _graficoVendasServico = graficoVendasServico ?? throw
                                    new ArgumentNullException(nameof(graficoVendasServico));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _graficoVendasServico.GetVendasLanches();

            return Json(lanchesVendasTotais);
        }

        [HttpGet]
        public IActionResult Index(int dias)
        {
            return View();
        }        
        
        [HttpGet]
        public IActionResult VendasMensal(int dias)
        {
            return View();
        }        
        
        [HttpGet]
        public IActionResult VendasSemanal(int dias)
        {
            return View();
        }
    }
}
