using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [DisplayName("Item Details")]
        public string ItemName { get; set; }
        [DisplayName("Weight (KG)")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "Please select a valid destination")]
        public Destination? Destination { get; set; }
        [Required(ErrorMessage = "Please select a valid source")]
        public Source? Source { get; set; }

        public string Status { get; set; }
        public virtual Customer Customer { get; set; }
    }
        

    }

    

