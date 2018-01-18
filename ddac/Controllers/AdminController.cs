using ddac.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ddac.Controllers
{
    public class AdminController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: Admin
        public ActionResult Index()
        {
            var vm = new User();
            if (Session["logged"] != null)
            {
                vm = (User)(Session["logged"]);
                ViewBag.Message = "Welcome back, " + vm.Username;
            }
            else
                return RedirectToAction("Login","Admin");
            return View(vm);
        }
        [HttpGet]
        public ActionResult Login()
        {
            var vm = new User
            {
                UserType = "guest"
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(User admin)
        {
            ModelState.Remove("Name");
            if (ModelState.IsValid)
            {
                User tempAdminVM = new User
                {
                    Username = admin.Username,
                    Password = admin.Password,
                    UserType = "admin",
                };
                if (tempAdminVM.Username.Equals("admin"))
                {
                    Session.Add("logged", tempAdminVM);
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Login", "Admin");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public new ActionResult User()
        {
            var vm = (User)Session["logged"];
            if (vm == null)
            {
                vm = new User
                {
                    UserType = "guest"
                };
            }
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

        public void AddAgent(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserType = "agent";
                db.Users.Add(user);
                db.SaveChanges();
                //return RedirectToAction("User");
            }

        }

        public ActionResult _EditAgent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditAgent([Bind(Include = "Password,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("User");
            }
            return View(user);
        }


        public JsonResult DoesUserNameExist(string UserName)
        {
            Boolean found = false;
            foreach (User user in db.Users)
            {
                if (user.Username.Equals(UserName))
                {
                    found = true;
                    break;
                }
            }
            //return Json(new { data = found }, JsonRequestBehavior.AllowGet);
            return new JsonResult { Data = found, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}