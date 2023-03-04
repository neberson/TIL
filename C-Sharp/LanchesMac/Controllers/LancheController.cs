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
        // var lanches = _lancheRepository.Lanches;
        //return View(lanches);

        //var lanchesListViewModel = new LancheListViewModel();
        //lanchesListViewModel.Lanches = _lancheRepository.Lanches;
        //lanchesListViewModel.CategoriaAtual = "Categoria Atual";

        IEnumerable<Lanche> Lanches;
        string categoriaAtual = string.Empty;
        if (string.IsNullOrEmpty(categoria))
        {
            Lanches = _lancheRepository.Lanches.OrderBy(lanche => lanche.LancheId);
            categoriaAtual = "Todos os lanches";
        } else
        {
            if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
            {
                Lanches = _lancheRepository.Lanches
                    .Where(lanche => lanche.Categoria.CategoriaNome.Equals("Normal"))
                    .OrderBy(lanche => lanche.Nome);
            }  else
            {
                Lanches = _lancheRepository.Lanches
                    .Where(lanche => lanche.Categoria.CategoriaNome.Equals("Natural"))
                    .OrderBy(lanche => lanche.Nome);
            }
            categoriaAtual = categoria;
        }

        var lanchesListViewModel = new LancheListViewModel
        {
            Lanches = Lanches,
            CategoriaAtual = categoriaAtual
        };

        return View(lanchesListViewModel);
    }
}
