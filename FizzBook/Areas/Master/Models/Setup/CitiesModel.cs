using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Setup
{
    public class CitiesModel
    {
        public Guid Id { get; set; }
        [Display(Name ="Name")]
        [Required(ErrorMessage ="Pleae provide city name")]
        public string CityName { get; set; }

        [Display(Name ="Country")]
        [Required(ErrorMessage ="Please select Country")]
        public Guid? CountryId { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }
        public List<SelectListItem> Countries { get; set; }

    }
}
