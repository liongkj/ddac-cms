﻿using System;
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
    public class ShipsController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: Ships
        public ActionResult Index()
        {
            return View(db.Ships.ToList());
        }

        // GET: Ships/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        // GET: Ships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ship ship)
        {
            if (ModelState.IsValid)
            {
                db.Ships.Add(ship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ship);
        }

        // GET: Ships/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        // POST: Ships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipName,IMO")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ship);
        }

        // GET: Ships/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        // POST: Ships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ship ship = db.Ships.Find(id);
            db.Ships.Remove(ship);
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
