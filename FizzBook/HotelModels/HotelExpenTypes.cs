using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class HotelExpenTypes
    {
        public HotelExpenTypes()
        {
            HotelExpense = new HashSet<HotelExpense>();
        }

        public Guid Id { get; set; }
        public string ExpenseType { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<HotelExpense> HotelExpense { get; set; }
    }
}
