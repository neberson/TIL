using LanchesMac.Context;
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
}
