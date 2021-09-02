using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Bookings
{
    public class HallBookingsModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CheckIn Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }
        [Required]
        [Display(Name = "CheckIn Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan CheckInTime { get; set; }
        [Required]
        [Display(Name = "CheckOut Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }
        [Required]
        [Display(Name = "CheckOut Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan CheckOutTime { get; set; }
        [Required]
        public string ContactNo { get; set; }
        public bool? IsDeleted { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsBookedOnline { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage ="Please select hall")]
        public Guid HallId { get; set; }
        [Required(ErrorMessage ="Pleae Select Hotel")]
        public Guid HotelId { get; set; }
        [Required(ErrorMessage ="Pleae select Building")]
        public Guid BuildingId { get; set; }
        public decimal? TotalBill { get; set; }
        public decimal? DiscountAmount { get; set; }

        [Display(Name = "Hotels")]
        public List<SelectListItem> Hotels { get; set; }
        [Display(Name = "Halls")]
        public List<SelectListItem> Halls { get; set; }
    }

}
