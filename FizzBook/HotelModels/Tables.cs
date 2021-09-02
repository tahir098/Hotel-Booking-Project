using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class Tables
    {
        public Guid Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string TableNo { get; set; }
        public Guid HotelId { get; set; }
        public string TableView { get; set; }
        public string Description { get; set; }
        public int? MaxNoOfPersons { get; set; }
        public decimal FarePerHour { get; set; }
        public Guid FloorId { get; set; }
        public Guid BuildingId { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsBooked { get; set; }
        public bool? IsBookedOnline { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
