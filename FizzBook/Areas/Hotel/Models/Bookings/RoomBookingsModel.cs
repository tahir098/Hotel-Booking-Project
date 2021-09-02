using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Models.Bookings
{
    public class RoomBookingsModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string RoomNo { get; set; }
        public string RoomImageUrl { get; set; }
        public string RoomDescription { get; set; }
        public int NightsCount { get; set; }
        public string BuildingName { get; set; }
        [Required(ErrorMessage = "Please select room type")]
        [Display(Name = "Room Type")]
        public Guid TypeId { get; set; }
        public string RoomTypeName { get; set; }
        public Guid UserId { get; set; }

        public decimal? FarePerNight { get; set; }
        public bool IsPaid { get; set; }
        public decimal? IsRemaining { get; set; }
        public int? NoOfRooms { get; set; }
        //[Required(ErrorMessage = "Select Check-In date")]
        [Display(Name = "CheckIn Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }
        //[Required(ErrorMessage = "Select Check-Out date")]
        [Display(Name = "CheckOut Date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }
        [Required(ErrorMessage = "Contact No is required")]
        public string ContactNo { get; set; }
        public string ServiceIdsString { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Adults { get; set; }
        public int? Childrens { get; set; }
        //[Required(ErrorMessage = "Select Check-In Time")]
        [Display(Name = "CheckIn Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckInTime { get; set; }
        //[Required(ErrorMessage = "Select Check-Out Time")]
        [Display(Name = "CheckOut Time")]
        [BindProperty, DataType(DataType.Time)]
        public TimeSpan? CheckOutTime { get; set; }
        [Required(ErrorMessage ="CNIC is required")]
        [MaxLength(13, ErrorMessage ="Maximum 13 numbers")]
        [MinLength(13,ErrorMessage ="Atleast 13 numbers")]
        public string CNIC { get; set; }
        public bool? IsDeleted { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [BindProperty, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int ServiceId { get; set; }
        public Guid RoomId { get; set; }
        public decimal? TotalBill { get; set; }
        public decimal? DiscountAmount { get; set; }
        public Guid HotelId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid FloorId { get; set; }
        [Display(Name = "Rooms")]
        public List<SelectListItem> Rooms { get; set; }

        [Display(Name = "Country")]
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Services { get; set; }

        [Display(Name = "City")]
        public List<SelectListItem> Cities { get; set; }

        [Display(Name = "Hotels")]
        public List<SelectListItem> Hotels { get; set; }

        [Display(Name = "Building")]
        public List<SelectListItem> Buildings { get; set; }

        [Display(Name = "Floor")]
        public List<SelectListItem> Floors { get; set; }
        [Display(Name = "Hotel Types")]
        public List<SelectListItem> RoomTypes { get; set; }

        public string HotelName { get; set; }
        public string FloorNo { get; set; }
        [Required]
        public int TotalNights { get; set; }
        public decimal TotalFare { get; set; }

        public List<int> ServiceIds { get; set; }
        public decimal? PaidAmount { get;  set; }
        public decimal? RemainingAmount { get;  set; }
    }
}
