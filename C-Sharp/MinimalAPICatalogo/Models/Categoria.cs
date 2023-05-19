using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPICatalogo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(500)]
        public string? Descricao { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
