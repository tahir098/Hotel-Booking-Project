using FizzBook.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly FizzHotleBookingContext _context;
        public ExpenseTypeRepository(FizzHotleBookingContext context)
        {
            _context = context;
        }
        public IList<ExpenseTypes> GetExpenseTypes()
        {
            IList<ExpenseTypes> expenseTypes = _context.ExpenseTypes.Where(p => p.IsDeleted != false).ToList();
            return expenseTypes;
        }
        public ExpenseTypes GetExpenseTypesById(string expenseTypeId)
        {
            ExpenseTypes expenseType = _context.ExpenseTypes.Where(p => p.Id == Guid.Parse(expenseTypeId) && p.IsDeleted != true).FirstOrDefault();
            return expenseType;
        }
    }
}
