using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Bookings
{
    public class TableBookingsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [BindProperty, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public decimal? FarePerHour { get; set; }

        [Display(Name = "CheckIn Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }

        [Display(Name = "CheckOut Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }
        [Required(ErrorMessage = "CNIC is required")]
        [MaxLength(13, ErrorMessage = "Maximum 13 numbers")]
        [MinLength(13, ErrorMessage = "Atleast 13 numbers")]
        public string CNIC { get; set; }

        [Display(Name = "Persons")]
        public int? NoOfPersons { get; set; }
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Select Check-In Time")]
        [Display(Name = "CheckIn Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckInTime { get; set; }

        [Display(Name = "CheckOut Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckOutTime { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public string TableNo { get; set; }
        public string Status { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsBookedOnline { get; set; }
        public Guid TableId { get; set; }
        public decimal? TotalBill { get; set; }
        public decimal? IsPaid { get; set; }
        public decimal? IsRemaining { get; set; }
        public decimal? DiscountAmount { get; set; }
        public Guid? HotelId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public decimal? TotalFare { get; set; }
        public Guid? FloorId { get; set; }
        public string HotelName { get; set; }
        public string BuildingName { get; set; }
        public string FloorNo { get; set; }
        public string TableView { get;  set; }
        public string Description { get;  set; }
        public int? MaxNoOfPersons { get; set; }
        public string ImageUrl { get;  set; }
        public List<SelectListItem> Services { get;  set; }
        public string ServiceIdsString { get; set; }
        public List<int> ServiceIds { get; set; }
        public decimal? PaidAmount { get;  set; }
        public decimal? RemainingAmount { get;  set; }
        public int? TotalHours { get;  set; }
    }
}
