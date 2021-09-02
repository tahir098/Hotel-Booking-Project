using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Controllers
{
    [Area("Hotel")]
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
