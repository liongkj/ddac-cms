using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class Parcel
    {
        public int ParcelId { get; set; }
        public int Capacity { get; set; }
        public int CusId { get; set; }
        [ForeignKey("CusId")]
        public virtual Customer Customer { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}