using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class CountriesModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Country Name is required")]
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
