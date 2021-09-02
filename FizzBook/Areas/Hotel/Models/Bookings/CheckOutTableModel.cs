using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Models.Bookings
{
    public class CheckOutTableModel
    {
        public Guid Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? NoOfPersons { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Status { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsBookedOnline { get; set; }
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
        public decimal? DiscountAmount { get; set; }
        public Guid? HotelId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public decimal? TotalFare { get; set; }
        public Guid? FloorId { get; set; }
        public decimal? IsRemaining { get; set; }
        public bool IsPaid { get; set; }
        public decimal? FarePerHour { get; set; }
        public int? TotalHours { get; set; }
        public decimal? TotalBill { get; set; }
        public decimal? RemainingAmount { get; set; }
        public decimal? PaidAmount { get; set; }

        public string TableNo { get; set; }
        public string ServiceIdsString { get; set; }
        public List<int> ServiceIds { get; set; }

        public List<SelectListItem> Services { get; set; }
        public decimal TableServicePrice { get; set; }
    }
}
