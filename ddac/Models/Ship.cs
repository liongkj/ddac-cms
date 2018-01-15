using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class Ship

    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int IMO { get; set; }
        public char Size { get; set; }

    }
}