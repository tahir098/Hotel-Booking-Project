using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.Models
{
    public partial class Officers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Roles Role { get; set; }
    }
}
