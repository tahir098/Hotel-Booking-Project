using FizzBook.HotelModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Models.Expense
{
    public class ExpenseModel
    {
        public Guid Id { get; set; }
        public Guid ExpenseTypeId { get; set; }
        [Required(ErrorMessage = "Expense Amount Required")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Expense Description Required")]
        public string ExpenseDescription { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        [Required]
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }

        public List<SelectListItem> Hotels { get; set; }


        public List<Expenses> Expenses { get; set; }
        public List<ExpenseTypes> ExpenseTypes { get; set; }


        public string HotelExpenseId { get; set; }
        [Required]
        public string HotelExpenTypeId { get; set; }

        public List<SelectListItem> HotelExpense { get; set; }
        public List<SelectListItem> HotelExpenTypes { get; set; }
    }
}
