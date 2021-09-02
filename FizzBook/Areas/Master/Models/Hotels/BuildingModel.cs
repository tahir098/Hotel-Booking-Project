using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class BuildingModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Display(Name = "Hotel")]
        [Required(ErrorMessage = "Please select hotel")]
        public Guid HotelId { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile BuildingImage { get; set; }
        public string HotelName { get; set; }
        public bool? IsDeleted { get; set; }
        public string Address { get; set; }
        [Display(Name = "Hotels")]
        public List<SelectListItem> Hotels { get; set; }
    }
}
