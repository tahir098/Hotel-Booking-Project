using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBook.Areas.Master.Models.Setup
{
    public class CompaniesModel
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
