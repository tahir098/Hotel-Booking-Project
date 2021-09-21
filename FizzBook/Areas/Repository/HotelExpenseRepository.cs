using FizzBook.HotelModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class HotelExpenseRepository : IHotelExpenseRepository
    {
        private readonly FizzHotleBookingContext _context;

        public HotelExpenseRepository(FizzHotleBookingContext context)
        {
            _context = context;
        }
        public IList<HotelExpense> GetHotelExpense()
        {
            List<HotelExpense> expenses = _context.HotelExpense.Where(p => p.IsDeleted == false).Include(x => x.Hotel).Include(x => x.ExpenseType).ToList();
            return expenses;
        }
        public HotelExpense GetHotelExpenseById(string hotelExpenseId)
        {
            HotelExpense expenses = _context.HotelExpense.Where(p => p.Id == Guid.Parse(hotelExpenseId) && p.IsDeleted != true).FirstOrDefault();
            return expenses;
        }
    }
}
