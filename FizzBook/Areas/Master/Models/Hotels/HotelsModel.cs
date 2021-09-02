using FizzBook.Areas.Master.Models.Setup;
using FizzBook.HotelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class HotelsModel
    {
        public Guid Id { get; set; }
        public string HotelLogo { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string HotelPhone { get; set; }
        public string HotelMobile { get; set; }
        [Required]
        public string HotelEmail { get; set; }
        [Required]
        public string HotelAddress { get; set; }
        public string HotelWebsite { get; set; }
        [Required]
        public Guid HotelCityId { get; set; }
        [Required]
        public Guid HotelCountryId { get; set; }
        public Guid HotelTypeId { get; set; }
        public bool? IsDeleted { get; set; }
        public IFormFile HotelImage { get; set; }
        public string ImageUrl { get; set; }
        public string HotelType { get; set; }
       // [Required]
        public string City { get; set; }
        //[Required]
        public string Country { get; set; }
        [Required]
        public string Password { get; set; }

        [Display(Name = "Hotel Type")]
        public List<SelectListItem> HotelTypes { get; set; }
        [Display(Name = "Cities")]
        public List<SelectListItem> Cities { get; set; }
        [Display(Name = "Countries")]
        public List<SelectListItem> Countries { get; set; }
    }
}
