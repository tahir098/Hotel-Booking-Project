using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class HotelBookings
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public DateTime CheckInDate { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public DateTime CheckOutDate { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Email { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsBookedOnline { get; set; }
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }
        public decimal? TotalBill { get; set; }
        public decimal? DiscountAmount { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
        public decimal? Fare { get; set; }
    }
}
