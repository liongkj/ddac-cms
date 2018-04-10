using ddac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddac.ViewModels
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }
        public Schedule Schedule { get; set; }

        public List<Item> Items { get; set; }

    }
}