using System.Collections.Generic;

namespace ddac.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public virtual Schedule Schedule{get;set;}
        public virtual Item Item { get; set; }
        public virtual User Agent { get; set; }
        public string Status { get; set; }

    }
}