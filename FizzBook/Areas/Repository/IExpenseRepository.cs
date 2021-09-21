using FizzBook.HotelModels;
using System.Collections.Generic;

namespace FizzBook.Areas.Repository
{
    public interface IExpenseRepository
    {
        IList<Expenses> GetExpenses();
        Expenses GetExpenseById(string expenseId);
    }
}