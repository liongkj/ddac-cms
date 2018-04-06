using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        [ForeignKey("Booking")]
        public Booking BookingId { get; set; }
        public virtual Booking Booking { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}