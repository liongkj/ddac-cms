using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ddac.Models;

namespace ddac.Controllers
{
    public class SchedulesController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: Bookings
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

        public PartialViewResult _ScheduleList()
        {
            return PartialView(db.Schedules.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule booking = db.Schedules.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public PartialViewResult _Create()
        { 
            var shiplist = db.Ships
                .AsEnumerable()
                .Select(s => new {
                    s.ShipId,
                    ShipName = string.Format("{0} -- Ship Size {1} KG", s.ShipName, s.IMO)
                })
                .ToList();
            //ViewBag.shipdropdown = new SelectList(shiplist, "ShipId", "ShipName");
            ViewBag.shipdropdown = shiplist;
            return PartialView();
        }


        
        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {

            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
            }
            return Redirect("Index");


        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule booking = db.Schedules.Find(id);
            var shiplist = db.Ships
                 .AsEnumerable()
                 .Select(s => new {
                     s.ShipId,
                     ShipName = string.Format("{0} -- Ship Size {1} KG", s.ShipName, s.IMO)
                 })
                 .ToList();
            //ViewBag.shipdropdown = new SelectList(shiplist, "ShipId", "ShipName");
            ViewBag.shipdropdown = shiplist;
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Departure,Arrival,ShipId,Destination,Source")] Schedule booking)
        {

            var shiplist = db.Ships
                .AsEnumerable()
                .Select(s => new {
                    s.ShipId,
                    ShipName = string.Format("{0} -- Ship Size {1} KG", s.ShipName, s.IMO)
                })
                .ToList();
            //ViewBag.shipdropdown = new SelectList(shiplist, "ShipId", "ShipName");
            ViewBag.shipdropdown = shiplist;

            if (ModelState.IsValid)
            {

                db.Entry(booking).State = EntityState.Added;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule booking = db.Schedules.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule booking = db.Schedules.Find(id);
            db.Schedules.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
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
