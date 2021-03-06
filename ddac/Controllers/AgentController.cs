﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ddac.Models;
using ddac.ViewModels;
using static ddac.Models.Customer;

namespace ddac.Controllers
{
    public class AgentController : Controller
    {
        private UserDBContext db = new UserDBContext();


        // GET: Customers
        public ActionResult Index()
        {
            var vm = new User();
            if (Session["logged"] != null)
            {
                vm = (User)(Session["logged"]);
                ViewBag.Message = "Welcome back, " + vm.Username;
            }
            else
                return RedirectToAction("Login", "Admin");
            return View(vm);
        }

        public ActionResult Customer()
        {
            var vm = new User();
            if (Session["logged"] != null)
            {
                vm = (User)(Session["logged"]);
                ViewBag.Message = "Welcome back, " + vm.Username;

            }
            else
                return RedirectToAction("Login", "Admin");

            return View(vm);

        }

        public PartialViewResult _CustomerList()
        {
            var agent = (User)(Session["logged"]);
            IQueryable<Customer> model = db.Customers
                .Where(c => c.Agent.UserId == agent.UserId)
                .Include(c => c.Agent);

            return PartialView(model);

        }

        [HttpGet]
        public PartialViewResult _AddCustomer()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _AddCustomer(Customer customer1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var agent = (User)Session["logged"];
                    customer1.Agent = null;
                    customer1.UserId = agent.UserId;
                    db.Customers.Add(customer1);

                    db.SaveChanges();
                    return RedirectToAction("Customer", "Agent");
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

            }

            return View();
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CusId,Username,Password,UserType,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Customer", "Agent");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }



            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditCus([Bind(Include = "Name,ShippingAddress")]int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var updatedCus = db.Customers.Find(id);
            if (ModelState.IsValid)
            {
                if (TryUpdateModel(updatedCus, "", new string[] { "Name", "ShippingAddress" }))
                {
                    db.SaveChanges();
                    return RedirectToAction("Customer");
                }
                
            }
            return View(updatedCus);
        }

            // GET: Customers/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            IQueryable<Item> items = db.Items
               .Where(c => c.Customer.CusId == id)
               .Include(c => c.Customer);

            foreach (Item i in items)
            {
                db.Items.Remove(i);
            }

            db.SaveChanges();
            return RedirectToAction("Customer");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
