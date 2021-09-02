using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Setup
{
    public class HotelTypesModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Hotel Type is required")]
        [MaxLength(50)]
        public string Type { get; set; }
        public bool? IsDeleted { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

    }
}
