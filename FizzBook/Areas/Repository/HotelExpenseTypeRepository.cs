using FizzBook.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public class HotelExpenseTypeRepository : IHotelExpenseTypeRepository
    {
        private readonly FizzHotleBookingContext _context;
        public HotelExpenseTypeRepository(FizzHotleBookingContext context)
        {
            _context = context;
        }
        public IList<HotelExpenTypes> GetHotelExpenseTypes()
        {
            IList<HotelExpenTypes> expenseTypes = _context.HotelExpenTypes.Where(p => p.IsDeleted != false).ToList();
            return expenseTypes;
        }
        public HotelExpenTypes GetHotelExpenseTypesById(string hotelExpenseTypeId)
        {
            HotelExpenTypes expenseType = _context.HotelExpenTypes.Where(p => p.Id == Guid.Parse(hotelExpenseTypeId) && p.IsDeleted != true).FirstOrDefault();
            return expenseType;
        }
    }
}
