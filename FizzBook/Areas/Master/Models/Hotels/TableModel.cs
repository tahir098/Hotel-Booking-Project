using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class TableModel
    {
        public Guid Id { get; set; }
        public bool? IsDeleted { get; set; }
        [Required(ErrorMessage ="Table Number")]
        public string TableNo { get; set; }
        [Required(ErrorMessage = "Please select")]
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public string TableView { get; set; }
        public string BuildingName { get; set; }
        public bool? IsAvailable { get; set; }
        public string FloorNo { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile TableImage { get; set; }
        public string Description { get; set; }
        [Display(Name = "Persons")]
        [Required(ErrorMessage = "Please select")]
        public int? MaxNoOfPersons { get; set; }
        public decimal? FarePerHour { get; set; }
        [Required(ErrorMessage = "Please select")]
        public Guid FloorId { get; set; }
        [Required(ErrorMessage = "Please select")]
        public Guid BuildingId { get; set; }
        [Display(Name = "Hotels")]
        public List<SelectListItem> Hotels { get; set; }
        [Display(Name = "Buildings")]
        public List<SelectListItem> Buildings { get; set; }
        [Display(Name = "Floors")]
        public List<SelectListItem> Floors { get; set; }
    }
}
