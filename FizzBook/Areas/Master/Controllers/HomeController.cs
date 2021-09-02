using FizzBook.Areas.Master.ViewModals;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Controllers
{
    [Area("Master")]
    public class HomeController : Controller
    {
        private FizzHotleBookingContext _context;

        public HomeController(FizzHotleBookingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModal modal)
        {
            if (ModelState.IsValid)
            {
                //var tmep = _context.HotelOfficers.Where(p => p.UserName == modal.Username && p.Password == modal.Password).FirstOrDefault();

                var tmep = _context.Officers.Where(p => p.UserName == modal.Username && p.Password == modal.Password).FirstOrDefault();

                if (tmep != null)
                {
                    HttpContext.Session.SetString("UserId", Convert.ToString(tmep.Id));
                    return RedirectToAction("Index", "Dashboard", new { area = "Master" });

                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Home", new { area = "Master" });

        }
    }
}
