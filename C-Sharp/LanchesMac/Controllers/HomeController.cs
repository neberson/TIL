using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesMac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;

        public HomeController(ILanchesRepository branchesRepository)
        {
            _lanchesRepository = branchesRepository;
        }

        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lanchesRepository.LanchesPreferidos.ToList()
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}