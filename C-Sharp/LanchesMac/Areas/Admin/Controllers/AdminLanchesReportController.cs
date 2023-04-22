using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using LanchesMac.Areas.Admin.FastReportUtils;
using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLanchesReportController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly RelatorioLanchesService _relatorio;

        public AdminLanchesReportController(IWebHostEnvironment environment, RelatorioLanchesService relatorio)
        {
            _environment = environment;
            _relatorio = relatorio;
        }

        public async Task<ActionResult> LanchesCategoriaReport()
        {
            var webReport = new WebReport();

            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_environment.ContentRootPath, "wwwroot/reports", "LanchesCategoria.frx"));

            var lanches = HelperFastReport.GetTable(await _relatorio.GetLanchesReport(),"LanchesReport");
            var categorias = HelperFastReport.GetTable(await _relatorio.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(lanches, "LancheReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
