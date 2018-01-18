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
        //[Remote("DoesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        [Index(IsUnique = true)]
        [Required(ErrorMessage = "Please write your Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please write your Password")]
        public string Password { get ; set; }
        public string UserType { get ; set; }
        [Required(ErrorMessage = "Please write your Name")]
        public string Name { get; set ; }
        public User Agent { get; set; }

    }

}