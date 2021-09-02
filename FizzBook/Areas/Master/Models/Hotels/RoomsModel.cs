using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class RoomsModel
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public decimal FarePerNight { get; set; }

        [NotMapped]
        [Display(Name = "Room Image")]
        public IFormFile RoomImage { get; set; }
        public string ImageName { get; set; }
        public decimal DiscountAmount { get; set; }

        public string RoomNo { get; set; }
        [MaxLength(200, ErrorMessage = "Description should not more then 300 characters")]
        public string Description { get; set; }
        public int? MaxNoOfPersons { get; set; }
        public string RoomView { get; set; }
        public int? NoOfBeds { get; set; }
        public Guid ServiceId { get; set; }
        public bool? IsDeleted { get; set; }
        public List<Guid> ServiceIds { get; set; }
        public string ServiceIdsString { get; set; }
        public string HotelName { get; set; }

        public bool? IsBooked { get; set; }
        public bool? IsAvailable { get; set; }
        public string BuildingName { get; set; }
        public string FloorNo { get; set; }
        public Guid FloorId { get; set; }
        public string ImageUrl { get; set; }
        public Guid BuildingId { get; set; }
        public Guid HotelId { get; set; }
        public List<SelectListItem> Services { get; set; }
        [Display(Name = "Hotels")]
        public List<SelectListItem> Hotels { get; set; }
        [Display(Name = "Room Type")]
        public List<SelectListItem> Types { get; set; }
        [Display(Name = "Buildings")]
        public List<SelectListItem> Buildings { get; set; }
        [Display(Name = "Floors")]
        public List<SelectListItem> Floors { get; set; }

    }
}
