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


        private UserDBContext db = new UserDBContext();

        // GET: Admin
        public ActionResult Index(User admin)
        {
            TempData["logged"] = "guest";
            var vm = admin;
            return View(vm);
        }

        public ActionResult Login()
        {
            TempData["logged"] = "guest";
            var vm = new User
            {
                UserType = "guest"
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(User admin)
        {

            User tempAdminVM = new User
            {
                Username = admin.Username,
                Password = admin.Password,
                UserType = "admin",
            };

            if (tempAdminVM.Username.Equals("admin"))
            {
                TempData["logged"] = "admin";
                return RedirectToAction("Index", "Admin", tempAdminVM);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public new ActionResult User(User admin)
        {

            var vm = new User();
            return View(vm);
        }

        public PartialViewResult _AgentList()
        {
            return PartialView(db.Users);
        }

        public PartialViewResult _AddAgent()
        {

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _AddAgent([Bind(Include = "ID,Username,Password,UserType,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("User", new User { UserType ="admin"});
            }
            return View(user);
        }

    }
}