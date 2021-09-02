using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FizzBook.HotelModels
{
    public partial class RoomServices
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public Guid RoomId { get; set; }

        public virtual Rooms Room { get; set; }
        public virtual Services Service { get; set; }
    }
}
