using ddac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddac.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(UserModel admin)
        {
            var vm = admin;
            return View(vm);
        }

        public ActionResult Login() {
            var vm = new UserModel();
            vm.UserType = "guest";
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(UserModel admin) {
            var tempAdminVM = new UserModel
            {
                Username = admin.Username,
                Password = admin.Password,
                UserType = "admin",
            };


            if (tempAdminVM.Username.Equals("admin"))
            {
                    return RedirectToAction("Index", "Admin", tempAdminVM);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult Add_Agent(UserModel admin) {
            var vm = admin;
            return View(vm);
        }
    }
}