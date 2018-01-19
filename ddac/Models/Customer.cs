using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddac.Models
{
    public class Customer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CusId { get; set; }
        [Required(ErrorMessage = "Please write your Name")]
        public string Name { get; set ; }
        public User Agent { get; set; }
        
        [ComplexType]
        public class Address
        {
            public string Addressline1 { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string StateOrProvince { get; set; }
            public string Country { get; set; }
        }

    }

}