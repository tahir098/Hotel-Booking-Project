using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Hotels
{
    public class ServicesModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Service Name Required")]
        public string ServiceName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
