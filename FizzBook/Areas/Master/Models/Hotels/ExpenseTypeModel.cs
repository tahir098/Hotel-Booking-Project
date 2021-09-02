using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class ExpenseTypeModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Expense Type is required")]
        public string ExpenseType { get; set; }
        public bool IsDeleted { get; set; }

        public Guid HotelId { get; set; }
    }
}
