using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Hotel.Models.Hotels
{
    public class HallModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select Hotel")]
        public Guid HotelId { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile HallImage { get; set; }
        public string Height { get; set; }
        public string HotelName { get; set; }
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        
        public string BuildingName { get; set; }
        public string FloorNo { get; set; }
        public string RoomSize { get; set; }
        public bool? IsDeleted { get; set; }
        [Display(Name = "Hotels")]
        public List<SelectListItem> Hotels { get; set; }
        [Display(Name = "Building")]
        public List<SelectListItem> Buildings { get; set; }
        [Display(Name = "Floor")]
        public List<SelectListItem> Floors { get; set; }
        public decimal? Fare { get; set; }

        public List<Guid> ServiceIds { get; set; }
    }
}
