using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class HotelOfficerRoles
    {
        public HotelOfficerRoles()
        {
            HotelOfficers = new HashSet<HotelOfficers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<HotelOfficers> HotelOfficers { get; set; }
    }
}
