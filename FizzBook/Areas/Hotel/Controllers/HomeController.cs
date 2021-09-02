using FizzBook.Areas.Hotel.ViewModals;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Controllers
{
    [Area("Hotel")]
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

                var tmep = _context.HotelOfficers.Where(p => p.UserName == modal.Username && p.Password == modal.Password).FirstOrDefault();

                if (tmep != null)
                {
                    HttpContext.Session.SetString("UserId", Convert.ToString(tmep.HotelId));
                    return RedirectToAction("Index", "Dashboard", new { area = "Hotel" });
                  
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Home", new { area = "Hotel" });

        }
    }
}
