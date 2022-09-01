using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aplics.Nominix.MVC.Controllers
{
    public class ExcepcionesExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> UploadFileExcel(List<IFormFile> file)
        {
            long size = file.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in file)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Json(new { data="1" });
        }
    }
}
