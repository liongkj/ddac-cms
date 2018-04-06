using ddac.Models;
using ddac.ViewModels;
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
            var viewmodel = new AgentViewModel();
            if (Session["logged"] != null)
            {
                vm = (User)(Session["logged"]);
                ViewBag.Message = "Welcome back, " + vm.Username;
                vm.UserType = "admin";
                viewmodel.Agent = vm;

            }
            else
                return RedirectToAction("Login", "Admin");
            return View(viewmodel);
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
        public ActionResult Login(User user)
        {
            var viewmodel = new AgentViewModel();
            User tempAdminVM = new User
            {
                Username = user.Username,
                Password = user.Password,
                UserType = "guest"
        };

            ModelState.Remove("Name");
            if (ModelState.IsValid)
            {
                
                if (tempAdminVM.Username.Equals("admin"))
                {
                    tempAdminVM.UserType = "admin";
                    Session.Add("logged", tempAdminVM);
                    
                                  
                    return RedirectToAction("Index", "Admin");
                }
                else if (Login(user.Username, user.Password))
                {
                    viewmodel.Agent = (User)Session["logged"];
                    return RedirectToAction("Index", "Agent");
                }
                else {
                    ModelState.AddModelError("", "Incorrect username or password");
                }
            }
            return View(new AgentViewModel { Agent = tempAdminVM});
        }

        public Boolean Login(string username, string password)
        {
            foreach (User user in db.Users)
            {
                if (username.Equals(user.Username))
                {
                    if (password == user.Password)
                    {
                        Session["logged"] = user;
                        return true;
                    }
                }
            }
            return false;
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public new ActionResult User()
        {
            var vm = new User();

            var viewmodel = new AgentViewModel();
            if (Session["logged"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else {
               
                vm = (User)(Session["logged"]);


                viewmodel.Agent = vm;
                
            }
            return View(viewmodel);

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