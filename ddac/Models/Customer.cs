using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Customer() {
            ShippingAddress = new Address();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CusId { get; set; }
        [Required(ErrorMessage = "Please enter a valid customer name")]
        public string Name { get; set ; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User Agent { get; set; }
        public Address ShippingAddress { get; set; }

        [ComplexType]
        public class Address
        {
            [DisplayName("Address Line 1")]
            [Required(ErrorMessage = "Please write a valid address")]
            public string Addressline1 { get; set; }
            [Required(ErrorMessage = "Please select a valid city")]
            public string City { get; set; }
            [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Postcode")]
            [Required(ErrorMessage = "Please select a valid Postcode")]
            public string Postcode { get; set; }
            [Required(ErrorMessage = "Please select a valid state")]
            [DisplayName("State")]
            public string StateOrProvince { get; set; }
            [Required(ErrorMessage = "Please select a valid country")]
            public Country? Country { get; set; }
        }

        public enum Country {
            Malaysia,
            Thailand,
            Singapore,
            Indonesia,
            Vietnam
        }

    }

}