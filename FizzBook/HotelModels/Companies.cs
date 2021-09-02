using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class Companies
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string CompanySite { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
