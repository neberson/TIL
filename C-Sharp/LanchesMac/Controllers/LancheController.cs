using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;
public class LancheController : Controller
{
    private readonly ILanchesRepository _lancheRepository;

    public LancheController(ILanchesRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult List(string categoria)
    {

        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;
        if (string.IsNullOrEmpty(categoria))
        {
            lanches = _lancheRepository.Lanches.OrderBy(lanche => lanche.LancheId);
            categoriaAtual = "Todos os lanches";
        } else
        {

            lanches = _lancheRepository.Lanches
                      .Where(lanche => lanche.Categoria.CategoriaNome.Equals(categoria))
                      .OrderBy(lanche => lanche.Nome);

            categoriaAtual = categoria;
        }

        var lanchesListViewModel = new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual = categoriaAtual
        };

        return View(lanchesListViewModel);
    }

    public IActionResult Details(int lancheId) 
    {
        var lanche = _lancheRepository.Lanches.FirstOrDefault(lanche => lanche.LancheId == lancheId);
        return View(lanche);
    }
}
