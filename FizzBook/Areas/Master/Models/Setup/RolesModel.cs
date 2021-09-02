using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Setup
{
    public class RolesModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
