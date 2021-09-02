using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Models.Bookings
{
    public class HallBookingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "CheckIn Date")]
        [Required]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }
        [Required(ErrorMessage = "Select Check-Out Time")]
        [Display(Name = "CheckIn Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckInTime { get; set; }
        [Display(Name = "CheckOut Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }
        [Display(Name = "CheckOut Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckOutTime { get; set; }
        public string ContactNo { get; set; }
        public bool? IsDeleted { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Email { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsBookedOnline { get; set; }
        public Guid UserId { get; set; }
        public Guid HallId { get; set; }
        public decimal? TotalBill { get; set; }
        public decimal? DiscountAmount { get; set; }
        public Guid? HotelId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
        public decimal? Fare { get; set; }
        public Guid? FloorId { get; set; }
        public List<int> ServiceIds { get; set; }
        public bool? IsLeave { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? IsPaid { get; set; }
        public decimal? RemainingAmount { get; set; }
        public string HotelName { get; set; }
        public string ServiceIdsString { get; set; }
        
        public string CNIC { get; set; }

        public string HallName { get; set; }
        public string HallDescription { get; set; }
        public int? DaysCount { get; set; }
        public string BuildingName { get;  set; }
        public string FloorNo { get; set; }
        public List<SelectListItem> Services { get;  set; }
    }
}
