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
    public class User
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        //[Remote("DoesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        
        [Required(ErrorMessage = "Please write your Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please write your Password")]
        public string Password { get ; set; }
        public string UserType { get ; set; }
        [Required(ErrorMessage = "Please write your Name")]
        public string Name { get; set ; }
        
    }

    public class UserDBContext : DbContext {
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public System.Data.Entity.DbSet<ddac.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<ddac.Models.Ship> Ships { get; set; }

        public System.Data.Entity.DbSet<ddac.Models.Schedule> Schedules { get; set; }

        public System.Data.Entity.DbSet<ddac.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ddac.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<ddac.Models.Booking> Bookings { get; set; }
    }

   

}