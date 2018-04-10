using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class Schedule
    {
        
        public int ScheduleId { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select a valid departure date")]
        public DateTime? Departure { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select a valid arrival date")]
        public DateTime Arrival { get; set; }
        [Required(ErrorMessage = "Please select a valid destination")]
        public Destination? Destination { get; set; }
        [Required(ErrorMessage = "Please select a valid source")]
        public Source? Source { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
        [Required(ErrorMessage = "Please select a valid Ship")]
        public int ShipId { get; set; }
        public decimal Weight { get; set; }

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