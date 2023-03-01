using LanchesMac.Models;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace LanchesMac.Components;
public class CarrinhoCompraResumo : ViewComponent
{
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
        _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
        _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.ObtemCarrinhoCompraItens();

        var carrinhoCompraVM = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra
        };

        return View(carrinhoCompraVM);
    }
}
