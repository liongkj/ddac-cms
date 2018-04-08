using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class Ship

    {   [Key]
        public int ShipId { get; set; }
        [Required(ErrorMessage = "Please enter a ship name")]
        public string ShipName { get; set; }
        
        [Required(ErrorMessage = "Please select a ship size")]
        public ShipSize? IMO { get; set; }
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
}