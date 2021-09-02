using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            RoomServices = new HashSet<RoomServices>();
        }

        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public string Description { get; set; }
        public int? MaxNoOfPersons { get; set; }
        public string RoomView { get; set; }
        public int? NoOfBeds { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid FloorId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid HotelId { get; set; }
        public string RoomNo { get; set; }
        public decimal FarePerNight { get; set; }
        public bool? IsBooked { get; set; }
        public string ImageUrl { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool? IsBookedOnline { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<RoomServices> RoomServices { get; set; }
    }
}
