using FizzBook.Areas.Hotel.Models.UserManagement;
using FizzBook.Areas.Repository;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Controllers
{
    [Area("Hotel")]
    public class UserManagmentController : BaseController
    {
        private readonly FizzHotleBookingContext _context;
        private readonly IHotelsRepository _hotelsRepository;

        public UserManagmentController(FizzHotleBookingContext context, IHotelsRepository hotelsRepository)
        {
            _context = context;
            _hotelsRepository = hotelsRepository;
        }


        #region Hotel Officer Roles

        public IActionResult HotelOfficerRoles()
        {
            var roles = _context.HotelOfficerRoles.Where(p => p.IsDeleted == null).ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddEditHotelOfficerRole(int id)
        {
            var model = new HotelOfficerRoles();
            if (id != 0)
            {
                var role = _context.HotelOfficerRoles.Where(p => p.Id == id).FirstOrDefault();
                if (role != null)
                {
                    model.Id = role.Id;
                    model.Name = role.Name;
                }
            }
            return PartialView("AddEditHotelOfficerRole", model);
        }

        [HttpPost]
        public IActionResult AddEditHotelOfficerRole(HotelOfficerRoles model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    var role = _context.HotelOfficerRoles.Where(p => p.Id == model.Id).FirstOrDefault();
                    role.Name = model.Name;
                    _context.HotelOfficerRoles.Update(role);
                    _context.SaveChanges();
                }
                else
                {
                    var role = new HotelOfficerRoles()
                    {
                        Name = model.Name,
                    };
                    _context.HotelOfficerRoles.Add(role);
                    _context.SaveChanges();
                }
            }
            return Json("");
        }


        public IActionResult DeleteHotelOfficerRole(int Id)
        {
            var role = _context.HotelOfficerRoles.Where(p => p.Id == Id).FirstOrDefault();
            if (role != null)
            {
                role.IsDeleted = true;
                _context.HotelOfficerRoles.Update(role);
                _context.SaveChanges();
            }
            return Json("");
        }

        #endregion

        #region Hotel Officer

        public IActionResult HotelOfficers()
        {
            var officers = _context.HotelOfficers.Where(r => r.HotelId == Guid.Parse(TheUser) &&
            (r.IsDeleted == null || r.IsDeleted == false)).Include(r => r.HotelOfficerRole).Include(x => x.Hotel).ToList();
            return View(officers);
        }

        public IActionResult AddEditHotelOfficer(Guid id)
        {
            var model = new HotelOfficerViewModel()
            {
                HotelOfficerRoles = _context.HotelOfficerRoles.Where(x => x.IsDeleted == null || x.IsDeleted == false).Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList(),
                //Hotels = _hotelsRepository.AllHotels().Select(x => new SelectListItem()
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.HotelName
                //}).ToList()
                HotelName = _hotelsRepository.GetHotelName(TheUser)

            };
            if (id != Guid.Empty)
            {
                var officer = _context.HotelOfficers.Where(p => p.Id == Guid.Parse(id.ToString())).FirstOrDefault();
                if (officer != null)
                {
                    model.HotelOfficerId = officer.Id;
                    model.Name = officer.Name;
                    model.Mobile = officer.Mobile;
                    model.UserName = officer.UserName;
                    model.Password = officer.Password;
                    model.HotelOfficerRoleId = officer.HotelOfficerRoleId;
                    model.CreatedDate = officer.CreatedDate;
                    model.HotelId = officer.HotelId;
                }
            }
            return PartialView("AddEditHotelOfficer", model);
        }

        [HttpPost]
        public IActionResult AddEditHotelOfficer(HotelOfficerViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.HotelOfficerId != Guid.Empty)
                {
                    var officer = _context.HotelOfficers.Where(p => p.Id == model.HotelOfficerId).FirstOrDefault();
                    officer.Name = model.Name;
                    officer.UserName = model.UserName;
                    officer.Password = model.Password;
                    officer.Mobile = model.Mobile;
                    officer.HotelOfficerRoleId = model.HotelOfficerRoleId;
                    officer.IsDeleted = model.IsDeleted;
                    officer.HotelId = Guid.Parse(TheUser);
                    _context.Update(officer);
                    _context.SaveChanges();
                }
                else
                {
                    var officer = new HotelOfficers()
                    {
                        Name = model.Name,
                        UserName = model.UserName,
                        Mobile = model.Mobile,
                        Password = model.Password,
                        CreatedDate = DateTime.Now,
                        HotelId = Guid.Parse(TheUser),
                        HotelOfficerRoleId = model.HotelOfficerRoleId,
                        Id = Guid.NewGuid(),
                        IsDeleted = false
                    };
                    _context.HotelOfficers.Add(officer);
                    _context.SaveChanges();
                }

            }
            return Json("");
        }

        public IActionResult DeleteHotelOfficer(Guid Id)
        {
            var officer = _context.HotelOfficers.Where(p => p.Id == Id).FirstOrDefault();
            if (officer != null)
            {
                officer.IsDeleted = true;
                _context.HotelOfficers.Update(officer);
                _context.SaveChanges();
            }
            return Json("");
        }

        #endregion

    }
}
