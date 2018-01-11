using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get ; set; }
        public string UserType { get ; set; }
        public string Name { get; set ; }
    }

    public class UserDBContext : DbContext {
      
        public System.Data.Entity.DbSet<ddac.Models.User> Users { get; set; }
    }
    
}