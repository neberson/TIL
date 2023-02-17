using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LanchesMac.Models;

[Table("CarrinhoCompraItens")]
public class CarrinhoCompraItem
{
    [Key]
    public int CarrinhoCompraItemId { get; set; }
    [Required(ErrorMessage = "Informe o lanche")]
    public Lanche? Lanche { get; set; }
    [Required(ErrorMessage = "Informe a quantidade")]
    [MinLength(1,ErrorMessage = "A quantidade mínima para item é {1}")]
    public int Quantidade { get; set; }
    [StringLength(100)]
    public string? CarrinhoCompraId { get; set; }

}
