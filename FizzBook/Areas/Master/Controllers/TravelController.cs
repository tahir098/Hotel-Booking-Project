using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Controllers
{
    [Area("Master")]
    public class TravelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllRoutes()
        {
            return View();
        }
        public IActionResult AddRoute()
        {
            return View();
        }
    }
}
