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
        [Required(ErrorMessage = "Please write your Username")]
        public int BookingId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string ShipSize { get; set; }
        public string Destination { get; set; }
        public string Source { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

    }

    public enum ShipSize
    {
        [Description("XS - 2000")]
        XS2000,
        [Description("S - 3000")]
        S3000,
        [Description("M - 5000")]
        M5000,
        [Description("L - 10000")]
        L10000,
        [Description("XL - 14000")]
        XL14000

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