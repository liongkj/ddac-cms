using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class Booking
    {
        
        public int BookingId { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select a valid departure date")]
        public DateTime? Departure { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select a valid arrival date")]
        public DateTime Arrival { get; set; }
        [Required(ErrorMessage = "Please select a ship size")]
        public ShipSize? ShipSize { get; set; }
        [Required(ErrorMessage = "Please select a valid destination")]
        public Destination? Destination { get; set; }
        [Required(ErrorMessage = "Please select a valid source")]
        public Source? Source { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

    }

    public enum ShipSize
    {
        [Display(Name = "L - 28000KG")]
        XS2000,
        [Display(Name = "M - 24000KG")]
        S3000,
        [Display(Name = "S - 10000KG")]
        M5000

    }

    public enum Destination
    {
        Malaysia,
        Thailand,
        Singapore,
        Indonesia,
        Vietnam
    }

    public enum Source
    {
        Malaysia,
        Thailand,
        Singapore,
        Indonesia,
        Vietnam
    }

}