using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Setup
{
    public class HotelOfficerViewModel
    {
        public Guid HotelOfficerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Required]
        public string Mobile { get; set; }
        public bool? IsDeleted { get; set; }
        [Required]
        public int HotelOfficerRoleId { get; set; }
        [Required]
        public Guid HotelId { get; set; }
        public List<SelectListItem> HotelOfficerRoles { get; set; }

        public List<SelectListItem> Hotels { get; set; }

    }
}
