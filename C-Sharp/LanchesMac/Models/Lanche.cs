using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        #region "atributos da classe"
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "Informe o nome do Lanche")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1}")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descriação do lanche deve ser informada")]
        [Display(Name = "Descrição do Lanche")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1}")]
        public string? DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descriação detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1}")]
        public string? DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 999.99, ErrorMessage = "O preço deve estar entre 0,01 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
        #endregion

        #region "Relacionamento com a tabela categorias"
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
        #endregion
    }
}
