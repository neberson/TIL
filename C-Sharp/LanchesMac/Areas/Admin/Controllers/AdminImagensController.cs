using LanchesMac.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminImagensController(IOptions<ConfigurationImagens> myConfiguration, IWebHostEnvironment webHostEnvironment)
        {
            _myConfig = myConfiguration.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite (É permitido no máximo 10 arquivos).";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var file in files)
            {
                if (file.FileName.Contains(".jpg") || file.FileName.Contains(".gif") || file.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", file.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " + 
                                    $"com tamanho total de : {size} bytes";
            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }
    }
}
