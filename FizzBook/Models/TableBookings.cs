using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.Models
{
    public partial class TableBookings
    {
        public Guid Id { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? NoOfPersons { get; set; }
        public TimeSpan? CheckInTime { get; set; }
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
        public decimal? IsPaid { get; set; }
        public decimal? FarePerHour { get; set; }
    }
}
