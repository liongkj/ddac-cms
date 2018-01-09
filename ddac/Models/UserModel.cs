using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ddac.Models
{
    public class UserModel
    {
        string userid;
        string username;
        string password;
        string userType;
        string name;

        
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Userid { get => userid; set => userid = value; }
        public string UserType { get => userType; set => userType = value; }
        public string Name { get => name; set => name = value; }
    }
}