using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public virtual Customer Customer { get; set; }


        
    }

    
}
