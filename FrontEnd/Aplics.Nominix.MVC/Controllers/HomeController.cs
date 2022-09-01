using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aplics.Nominix.MVC.Authorize;
using Microsoft.AspNetCore.Mvc;

namespace Aplics.Nominix.MVC.Controllers
{
    [AccessAuthorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Minor()
        {

            return View();
        }

    }
}
