using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class HotelOfficers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Mobile { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid HotelId { get; set; }
        public int HotelOfficerRoleId { get; set; }

        public virtual Hotels Hotel { get; set; }
        public virtual HotelOfficerRoles HotelOfficerRole { get; set; }
    }
}
