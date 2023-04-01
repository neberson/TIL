namespace LanchesMac.Areas.Admin.ViewModel
{
    public class PaginacaoBase
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int QuantidadeRegistros { get; set; }
        public int TotalPages => (int)Math.Ceiling(QuantidadeRegistros / (double)PageSize);
    }
}
