using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class Menues
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool? IsMenu { get; set; }
        public bool? IsSubMenu { get; set; }
        public bool? IsAction { get; set; }
    }
}
