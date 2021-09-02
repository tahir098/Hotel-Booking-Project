using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.Models
{
    public partial class Hall
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid HotelId { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string RoomSize { get; set; }
        public bool? IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsBookedOnline { get; set; }
    }
}
