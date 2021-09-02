using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Setup
{
    public class HotelsModel
    {
        public Guid Id { get; set; }
        public string HotelLogo { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }
        public string HotelMobile { get; set; }
        public string HotelEmail { get; set; }
        public string HotelAddress { get; set; }
        public string HotelWebsite { get; set; }
        public Guid HotelCityId { get; set; }
        public Guid HotelCountryId { get; set; }
        public Guid? HotelTypeId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
