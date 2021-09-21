using FizzBook.HotelModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FizzHotleBookingContext _context;

        public ExpenseRepository(FizzHotleBookingContext context)
        {
            _context = context;
        }
        public IList<Expenses> GetExpenses()
        {
            List<Expenses> expenses = _context.Expenses.Include(x => x.ExpenseType).ToList().Where(p => p.IsDeleted == false).OrderBy(x => x.ExpenseType.ExpenseType).ToList();
            return expenses;
        }
        public Expenses GetExpenseById(string expenseId)
        {
            Expenses expenses = _context.Expenses.Where(p => p.Id == Guid.Parse(expenseId) && p.IsDeleted != true).FirstOrDefault();
            return expenses;
        }
    }
}
