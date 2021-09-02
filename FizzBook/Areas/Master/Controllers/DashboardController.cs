using FizzBook.Areas.Hotel.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Controllers
{
    [Area("Master")]
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
