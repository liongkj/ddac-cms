using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ddac.Models;
using ddac.ViewModels;

namespace ddac.Controllers
{
    public class BookingsController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }


        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,Status")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            //schedule id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User agent = (User)Session["logged"];
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            TempData["schedule"] = schedule;
            BookingViewModel ScheduleVM = new BookingViewModel
            {
                Schedule = schedule,
                //new SelectList(items, "ItemId", "ItemDetails")
            };

            return View(ScheduleVM);
        }



        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Status")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        public ActionResult Add(int? id)
        {
            //item id
            Schedule s = (Schedule)TempData["schedule"];
            User a = (User)Session["logged"];
            Item i = db.Items.Find(id);
            Booking NewBooking = new Booking()
            {
                Item = i,
                Schedule = s,
                Agent = a,
                Status = "pending"
            };
            db.Schedules.Attach(s);
            db.Users.Attach(a);
            db.Bookings.Add(NewBooking);
            db.SaveChanges();

            BookingViewModel bvm = new BookingViewModel
            {
                Schedule = s
            };
            return RedirectToAction("Edit", new { id = s.ScheduleId });
        }

        public PartialViewResult _ScheduleList()
        {
            IEnumerable<ScheduleViewModel> model = null;
            model = (from sche in db.Schedules
                     join ship in db.Ships
                     on sche.ShipId equals ship.ShipId
                     select new ScheduleViewModel
                     {
                         Schedule = sche,
                         Ship = ship
                     }
                                 );

            return PartialView(model);

        }

        public PartialViewResult _ItemList(int? id)
        {
            User agent = (User)Session["logged"];
            Schedule schedule = db.Schedules.Find(id);

            var items = db.Items
               .Where(i => i.Source == schedule.Source
               && i.Destination == schedule.Destination)
               .AsEnumerable()
               .ToList();

            var result = items.Where(p => !db.Bookings.Any(p2 => p2.Item.ItemId == p.ItemId));

            return PartialView(result);
        }


        public PartialViewResult _BookingList(int? id)
        {
            var schedule = db.Schedules.Find(id);
            //scheduleid
            var model = db.Bookings
               .Where(b => b.Schedule.ScheduleId == schedule.ScheduleId)
               .AsEnumerable()
               .ToList();

            return PartialView(model);
        }

        // GET: Bookings/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Booking booking = db.Bookings.Find(id);
        //    if (booking == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(booking);
        //}

        // POST: Bookings/Delete/5


        public ActionResult Delete(int? id)
        {
            Schedule s = (Schedule)TempData["schedule"];
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = s.ScheduleId });
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
