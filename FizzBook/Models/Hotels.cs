using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.Models
{
    public partial class Hotels
    {
        public Guid Id { get; set; }
        public string HotelLogo { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }
        public string HotelMobile { get; set; }
        public string HotelEmail { get; set; }
        public string HotelAddress { get; set; }
        public string HotelWebsite { get; set; }
        public Guid HotelCityId { get; set; }
        public Guid HotelCountryId { get; set; }
        public Guid HotelTypeId { get; set; }
        public bool? IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
    }
}
