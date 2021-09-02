using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.Models
{
    public partial class HotelTypes
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
    }
}
