using ddac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ddac.ViewModels
{
    public class AgentViewModel
    {
        public User Agent { get; set; }
        public Customer Customers { get; set; }
    }
}