using FizzBook.HotelModels;
using System.Collections.Generic;

namespace FizzBook.Areas.Repository
{
    public interface IExpenseTypeRepository
    {
        IList<ExpenseTypes> GetExpenseTypes();
        ExpenseTypes GetExpenseTypesById(string expenseTypeId);
    }
}