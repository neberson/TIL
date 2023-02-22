using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace LanchesMac.Models;
public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    public string CarrinhoCompraId { get; set; }
    public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public static CarrinhoCompra ObtemCarrinho(IServiceProvider services)
    {
        //define uma sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();

        //obtem ou gera o Id do carrinho
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        //atribui o id do carrinho na Sessão
        session.SetString("CarrinhoId", carrinhoId);

        //retorna o carrinho com o contexto e o Id atribuido ou obtido
        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoId
        };
    }

    public void AdicionarAoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItens.FirstOrDefault(
                                          lancheVerifica => lancheVerifica.Lanche.LancheId == lanche.LancheId &&
                                          lancheVerifica.CarrinhoCompraId == CarrinhoCompraId);

        if(carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Lanche = lanche,
                Quantidade = 1
            };
            _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
        } else
        {
            carrinhoCompraItem.Quantidade++;
        }
        _context.SaveChanges();
    }

    public void RemoverDoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItens.FirstOrDefault(
                                          lancheVerifica => lancheVerifica.Lanche.LancheId == lanche.LancheId &&
                                          lancheVerifica.CarrinhoCompraId == CarrinhoCompraId);

        if (carrinhoCompraItem != null)
        {
            if(carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
            }else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }
        }
        _context.SaveChanges();
    }

    public List<CarrinhoCompraItem> ObtemCarrinhoCompraItens()
    {
        return CarrinhoCompraItens ??
                (CarrinhoCompraItens =
                    _context.CarrinhoCompraItens
                    .Where(carrinhoItens => carrinhoItens.CarrinhoCompraId == CarrinhoCompraId)
                    .Include(lanche => lanche.Lanche)
                    .ToList()
                );
    }

    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItens
                            .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
        _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }

    public decimal ObtemCarrinhoCompraTotal()
    {
        return _context.CarrinhoCompraItens
               .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId)
               .Select(carrinho => carrinho.Lanche.Preco * carrinho.Quantidade).Sum();
    }
}
