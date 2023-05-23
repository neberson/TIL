using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimalAPICatalogo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(500)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(14,2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300)]
        public string? Imagem { get; set; }

        public DateTime DataCompra { get; set; }
        public int Estoque { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
