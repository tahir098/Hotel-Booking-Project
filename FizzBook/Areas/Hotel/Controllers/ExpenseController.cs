using FizzBook.Areas.Hotel.Models.Expense;
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
    public class ExpenseController : BaseController
    {
        private readonly IHotelsRepository _hotelsRepository;

        public FizzHotleBookingContext _context { get; }

        public ExpenseController(FizzHotleBookingContext context, IHotelsRepository hotelsRepository)
        {
            _context = context;
            _hotelsRepository = hotelsRepository;
        }

        #region Hotel Expense Type

        public IActionResult HotelExpenseTypes()
        {
            var model = _context.HotelExpenTypes.Where(p => p.IsDeleted == false).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddUpdateHotelExpenseType(Guid id)
        {
            var model = new HotelExpenTypes();
            if (id != Guid.Empty)
            {
                var tmep = _context.HotelExpenTypes.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.ExpenseType = tmep.ExpenseType;
                    model.Id = tmep.Id;
                    model.IsDeleted = tmep.IsDeleted;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddUpdateHotelExpenseType(Guid id, HotelExpenTypes model)
        {
            //var model = new ExpenseTypeModel();
            if (id != Guid.Empty)
            {

                var tmep = _context.HotelExpenTypes.Where(p => p.Id == id).FirstOrDefault();

                if (tmep != null)
                {

                    tmep.ExpenseType = model.ExpenseType;
                    tmep.Id = model.Id;
                    tmep.IsDeleted = false;

                    _context.HotelExpenTypes.Update(tmep);
                    _context.SaveChanges();
                }
            }
            else
            {
                var hotelExpenseType = new HotelExpenTypes()
                {
                    ExpenseType = model.ExpenseType,
                    IsDeleted = model.IsDeleted,
                    Id = Guid.NewGuid()

                    //model.ExpenseType = hotelExpenseType.ExpenseType,
                    //model.IsDeleted = hotelExpenseType.IsDeleted,
                    //model.Id = hotelExpenseType.Id,
                };

                _context.Add(hotelExpenseType);
                _context.SaveChanges();
            }
            return PartialView(model);
        }

        public IActionResult DeleteHotelExpenseType(Guid id)
        {
            var temp = _context.HotelExpenTypes.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                _context.Update(temp);
                _context.SaveChanges();
            }
            return Json("");
        }

        #endregion

        #region Hotel Expense

        public IActionResult HotelExpense()
        {
            var model = _context.HotelExpense.Where(p => p.HotelId == Guid.Parse(TheUser)
            && p.IsDeleted == false).Include(x => x.Hotel).Include(x => x.ExpenseType).ToList();
            List<HotelExpense> list = new List<HotelExpense>();
            foreach (var hotelExpense in list)
            {
                // var hotelName = _hotelsRepository.HotelNameById(hotelExpense.HotelId);
                var item = new HotelExpense()
                {
                    Amount = hotelExpense.Amount,
                    ExpenseDescription = hotelExpense.ExpenseDescription,
                    HotelId = Guid.Parse(TheUser),
                    CreationDate = hotelExpense.CreationDate,
                    IsDeleted = hotelExpense.IsDeleted

                };
                model.Add(item);

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUpdateHotelExpense(Guid id)
        {
            var model = new ExpenseModel();
            if (id != Guid.Empty)
            {
                var tmep = _context.HotelExpense.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.Id = tmep.Id;
                    model.ExpenseDescription = tmep.ExpenseDescription;
                    model.Amount = tmep.Amount.Value;
                    model.ExpenseTypeId = tmep.ExpenseTypeId.Value;
                    model.HotelId = tmep.HotelId;
                    model.IsDeleted = tmep.IsDeleted.Value;
                    model.HotelId = Guid.Parse(TheUser);
                }
            }
            var HotelExpenTypes = _hotelsRepository.GetHotelExpenseTypes();

            model.HotelExpenTypes = HotelExpenTypes.Select(x => new SelectListItem()
            {
                Value = x.Value.ToString(),
                Text = x.Text
            }).ToList();
            model.HotelName = _hotelsRepository.GetHotelName(TheUser);
            //model.Hotels = _hotelsRepository.AllHotels().Select(x => new SelectListItem()
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.HotelName
            //}).ToList();

            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddUpdateHotelExpense(Guid id, ExpenseModel model)
        {
            var hotelExpense = new HotelExpense();
            if (id != Guid.Empty)
            {

                var temp = _context.HotelExpense.Where(p => p.Id == id).FirstOrDefault();

                if (temp != null)
                {
                    temp.ExpenseDescription = model.ExpenseDescription;
                    temp.Amount = model.Amount;
                    temp.Id = model.Id;
                    temp.ExpenseTypeId = model.ExpenseTypeId;
                    temp.HotelId = Guid.Parse(TheUser);

                    _context.HotelExpense.Update(temp);
                    _context.SaveChanges();
                }

            }
            else
            {
                var hotelExpenseType = new HotelExpense()
                {
                    ExpenseDescription = model.ExpenseDescription,
                    IsDeleted = false,
                    Amount = model.Amount,
                    ExpenseTypeId = model.ExpenseTypeId,
                    CreationDate = DateTime.Now,
                    HotelId = Guid.Parse(TheUser),
                    Id = Guid.NewGuid(),
                    //model.ExpenseType = hotelExpenseType.ExpenseType,
                    //model.IsDeleted = hotelExpenseType.IsDeleted,
                    //model.Id = hotelExpenseType.Id,
                };

                _context.HotelExpense.Add(hotelExpenseType);
                _context.SaveChanges();
            }
            return PartialView(model);
        }

        public IActionResult DeleteHotelExpense(Guid id)
        {
            var temp = _context.HotelExpense.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                _context.Update(temp);
                _context.SaveChanges();
            }
            return Json("");
        }

        #endregion
    }
}
