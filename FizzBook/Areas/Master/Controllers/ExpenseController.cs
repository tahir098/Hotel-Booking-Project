using FizzBook.Areas.Hotel.Controllers;
using FizzBook.Areas.Master.Models.Hotels;
using FizzBook.Areas.Repository;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Controllers
{
    [Area("Master")]
    public class ExpenseController : Controller
    {
        private readonly IHotelsRepository _hotelsRepository;

        public FizzHotleBookingContext _Context { get; }

        public ExpenseController(FizzHotleBookingContext context, IHotelsRepository hotelsRepository)
        {
            _Context = context;
            _hotelsRepository = hotelsRepository;
        }

        public IActionResult ExpenseTypes()
        {
            var model = _Context.ExpenseTypes.Where(p => p.IsDeleted == false).ToList();
            return View(model);
        }



        [HttpGet]
        public IActionResult AddEditExpenseType(Guid id)
        {
            var model = new ExpenseTypeModel();
            if (id != Guid.Empty)
            {
                var tmep = _Context.ExpenseTypes.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.ExpenseType = tmep.ExpenseType;
                    model.Id = tmep.Id;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddEditExpenseType(ExpenseTypeModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id != Guid.Empty)
                {
                    var temp = _Context.ExpenseTypes.Where(p => p.Id == model.Id).FirstOrDefault();
                    temp.ExpenseType = model.ExpenseType;
                    _Context.Update(temp);
                    _Context.SaveChanges();
                }
                else
                {
                    var temp = new ExpenseTypes()
                    {
                        Id = Guid.NewGuid(),
                        ExpenseType = model.ExpenseType
                    };
                    _Context.Add(temp);
                    _Context.SaveChanges();
                }
            }
            return Json("");
        }
        public IActionResult DeleteExpenseType(Guid id)
        {
            var temp = _Context.ExpenseTypes.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                _Context.Update(temp);
                _Context.SaveChanges();
            }
            return Json("");
        }
        public IActionResult Expenses()
        {
            var model = _Context.Expenses.Include(x => x.ExpenseType).ToList().Where(p => p.IsDeleted == false).OrderBy(x => x.ExpenseType.ExpenseType);

            return View(model);
        }
        public IActionResult AddEditExpense(Guid id)
        {
            var model = new ExpenseModel()
            {
                ExpenseTypes = _Context.ExpenseTypes.Where(p => p.IsDeleted == false).ToList()

            };
            if (id != Guid.Empty)
            {
                var expense = _Context.Expenses.Where(p => p.Id == id).FirstOrDefault();
                if (expense != null)
                {
                    model.Id = expense.Id;
                    model.ExpenseTypeId = expense.ExpenseTypeId;
                    model.ExpenseDescription = expense.ExpenseDescription;
                    model.CreationDate = expense.CreationDate;
                    model.Amount = expense.Amount;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddEditExpense(ExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id != Guid.Empty)
                {
                    var expense = _Context.Expenses.Where(p => p.Id == model.Id).FirstOrDefault();
                    expense.ExpenseTypeId = model.ExpenseTypeId;
                    expense.CreationDate = DateTime.Now;
                    expense.ExpenseDescription = model.ExpenseDescription;
                    expense.Amount = model.Amount;

                    _Context.Update(expense);
                    _Context.SaveChanges();
                }
                else
                {
                    var expense = new Expenses()
                    {
                        Id = Guid.NewGuid(),
                        Amount = model.Amount,
                        CreationDate = DateTime.Now,
                        ExpenseDescription = model.ExpenseDescription,
                        ExpenseTypeId = model.ExpenseTypeId,
                    };
                    _Context.Add(expense);
                    _Context.SaveChanges();
                }

            }
            return Json("");
        }

        public IActionResult DeleteExpense(Guid id)
        {
            var temp = _Context.Expenses.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                _Context.Update(temp);
                _Context.SaveChanges();
            }
            return Json("");
        }


        #region Hotel Expense

        public IActionResult HotelExpense()
        {
            var model = _Context.HotelExpense.Where(p => p.IsDeleted == false).Include(x => x.Hotel).Include(x => x.ExpenseType).ToList();
            List<HotelExpense> list = new List<HotelExpense>();
            foreach (var hotelExpense in list)
            {
                // var hotelName = _hotelsRepository.HotelNameById(hotelExpense.HotelId);
                var item = new HotelExpense()
                {
                    Amount = hotelExpense.Amount,
                    ExpenseDescription = hotelExpense.ExpenseDescription,

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
                var tmep = _Context.HotelExpense.Where(p => p.Id == id).FirstOrDefault();
                if (tmep != null)
                {
                    model.Id = tmep.Id;
                    model.ExpenseDescription = tmep.ExpenseDescription;
                    model.Amount = tmep.Amount.Value;
                    model.ExpenseTypeId = tmep.ExpenseTypeId.Value;
                    model.HotelId = tmep.HotelId;
                    model.IsDeleted = tmep.IsDeleted.Value;
                    //model.HotelExpenTypes = _hotelsRepository.GetHotelExpenseTypes();
                    //model.HotelExpenTypes = new SelectList(HotelExpenTypes, "Value", "Text");


                    // model.hotel
                    // model.Expenses = 
                    //model.ExpenseTypes = new SelectListItem
                    //{

                    //}
                }

            }
            var HotelExpenTypes = _hotelsRepository.GetHotelExpenseTypes();

            model.HotelExpenTypes = HotelExpenTypes.Select(x => new SelectListItem()
            {
                Value = x.Value.ToString(),
                Text = x.Text
            }).ToList();

            model.Hotels = _hotelsRepository.AllHotels().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.HotelName
            }).ToList();

            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddUpdateHotelExpense(Guid id, ExpenseModel model)
        {
            var hotelExpense = new HotelExpense();
            if (id != Guid.Empty)
            {

                var temp = _Context.HotelExpense.Where(p => p.Id == id).FirstOrDefault();

                if (temp != null)
                {
                    temp.ExpenseDescription = model.ExpenseDescription;
                    temp.Amount = model.Amount;
                    temp.Id = model.Id;
                    temp.ExpenseTypeId = model.ExpenseTypeId;
                    temp.HotelId = model.HotelId;

                    _Context.HotelExpense.Update(temp);
                    _Context.SaveChanges();
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
                    HotelId = model.HotelId,
                    Id = Guid.NewGuid(),
                    //model.ExpenseType = hotelExpenseType.ExpenseType,
                    //model.IsDeleted = hotelExpenseType.IsDeleted,
                    //model.Id = hotelExpenseType.Id,
                };

                _Context.HotelExpense.Add(hotelExpenseType);
                _Context.SaveChanges();
            }
            return PartialView(model);
        }

        public IActionResult DeleteHotelExpense(Guid id)
        {
            var temp = _Context.HotelExpense.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                _Context.Update(temp);
                _Context.SaveChanges();
            }
            return Json("");
        }

        #endregion


        #region Hotel Expense Type

        public IActionResult HotelExpenseTypes()
        {
            var model = _Context.HotelExpenTypes.Where(p => p.IsDeleted == false).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddUpdateHotelExpenseType(Guid id)
        {
            var model = new HotelExpenTypes();
            if (id != Guid.Empty)
            {
                var tmep = _Context.HotelExpenTypes.Where(p => p.Id == id).FirstOrDefault();
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

            if (ModelState.IsValid)
            {

                if (id != Guid.Empty)
                {

                    var tmep = _Context.HotelExpenTypes.Where(p => p.Id == id).FirstOrDefault();

                    if (tmep != null)
                    {

                        tmep.ExpenseType = model.ExpenseType;
                        tmep.Id = model.Id;
                        tmep.IsDeleted = false;

                        _Context.HotelExpenTypes.Update(tmep);
                        _Context.SaveChanges();
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

                    _Context.Add(hotelExpenseType);
                    _Context.SaveChanges();
                }
            }
            return PartialView(model);
        }

        public IActionResult DeleteHotelExpenseType(Guid id)
        {
            var temp = _Context.HotelExpenTypes.Where(p => p.Id == id).FirstOrDefault();
            if (temp != null)
            {
                temp.IsDeleted = true;
                _Context.Update(temp);
                _Context.SaveChanges();
            }
            return Json("");
        }

        #endregion
    }
}
