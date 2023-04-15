using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
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
        public IActionResult Index()
        {
            return View();
        }        
        
        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }        
        
        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
