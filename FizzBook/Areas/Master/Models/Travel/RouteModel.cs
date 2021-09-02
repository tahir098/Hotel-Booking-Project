using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Travel
{
    public class RouteModel
    {
        public Guid Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
