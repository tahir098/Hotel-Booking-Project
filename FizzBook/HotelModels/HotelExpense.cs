using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class HotelExpense
    {
        public Guid Id { get; set; }
        public Guid? ExpenseTypeId { get; set; }
        public int? Amount { get; set; }
        public string ExpenseDescription { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid HotelId { get; set; }

        public virtual HotelExpenTypes ExpenseType { get; set; }
        public virtual Hotels Hotel { get; set; }
    }
}
