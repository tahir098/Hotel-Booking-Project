using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class FloorModel
    {
        public Guid Id { get; set; }
        public string FloorNo { get; set; }
        public Guid BuildingId { get; set; }
        public IFormFile FloorImage { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public string BuildingName { get; set; }
        public string HotelName { get; set; }
        public Guid HotelId { get; set; }
        public List<SelectListItem> Buildings { get; set; }
        public List<SelectListItem> Hotels { get; set; }

    }
}
