using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplics.Nominix.MVC.Controllers
{
    public class ProcesosNominaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
