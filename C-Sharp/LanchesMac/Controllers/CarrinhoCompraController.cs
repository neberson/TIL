using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace LanchesMac.Controllers;
public class CarrinhoCompraController : Controller
{
    private readonly ILanchesRepository _lancheRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ILanchesRepository lancheRepository, CarrinhoCompra carrinhoCompra)
    {
        _lancheRepository = lancheRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Index()
    {
        _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.ObtemCarrinhoCompraItens();

        var carrinhoCompraVM = new CarrinhoCompraViewModel 
        {
            CarrinhoCompra = _carrinhoCompra
        };

        return View(carrinhoCompraVM);
    }

    [Authorize]
    public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
    {
        var lancheSelecionado = _lancheRepository.GetLancheById(lancheId);

        if(lancheSelecionado != null)
        {
            _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
        }
        return RedirectToAction("Index");
    }

    [Authorize]
    public RedirectToActionResult RemoverItemNoCarrinhoCompra(int lancheId)
    {
        var lancheSelecionado = _lancheRepository.GetLancheById(lancheId);

        if (lancheSelecionado != null)
        {
            _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
        }
        return RedirectToAction("Index");
    }
}
