using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class Cities
    {
        public Cities()
        {
            Hotels = new HashSet<Hotels>();
        }

        public Guid Id { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? CountryId { get; set; }

        public virtual ICollection<Hotels> Hotels { get; set; }
    }
}
