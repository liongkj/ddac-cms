using ddac.Models;
using ddac.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddac.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new User
            {
                UserType = "guest"
            };

            var viewmodel = new AgentViewModel
            {
                Agent = vm
            };
            return View(viewmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}