using FizzBook.HotelModels;
using System.Collections.Generic;

namespace FizzBook.Areas.Repository
{
    public interface IHotelExpenseTypeRepository
    {
        IList<HotelExpenTypes> GetHotelExpenseTypes();
        HotelExpenTypes GetHotelExpenseTypesById(string hotelExpenseTypeId);
    }
}