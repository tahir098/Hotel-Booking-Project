using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Bookings
{
    public class HotelBookingsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        [Display(Name = "CheckIn Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }

        [Display(Name = "CheckIn Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckInTime { get; set; }

        [Display(Name = "CheckOut Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }
        [Display(Name = "CheckOut Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckOutTime { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Status { get; set; }
    }
}
