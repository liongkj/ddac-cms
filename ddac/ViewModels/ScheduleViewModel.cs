using ddac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ddac.ViewModels
{
    public class ScheduleViewModel
    {
        public Schedule Schedule { get; set; }
        public Ship Ship { get; set; }
    }
}