using FizzBook.HotelModels;
using System.Collections.Generic;

namespace FizzBook.Areas.Repository
{
    public interface IHotelExpenseRepository
    {
        IList<HotelExpense> GetHotelExpense();
        HotelExpense GetHotelExpenseById(string hotelExpenseId);
    }
}