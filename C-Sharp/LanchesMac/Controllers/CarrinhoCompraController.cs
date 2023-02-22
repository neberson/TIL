using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;
public class CarrinhoCompraController : Controller
{
    private readonly ILanchesRepository _branchesRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ILanchesRepository branchesRepository, CarrinhoCompra carrinhoCompra)
    {
        _branchesRepository = branchesRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Index()
    {
        return View();
    }
}
