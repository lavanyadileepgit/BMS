﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Busmanagemnetsystem.Controllers
{
    public class BusesController : Controller
    {
        private BusmanagementsystemEntities db = new BusmanagementsystemEntities();

        // GET: Buses
        public ActionResult Index()
        {
            var buses = db.Buses.Include(b => b.AvailableSeat);
            return View(buses.ToList());
        }

        // GET: Buses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: Buses/Create
        public ActionResult Create()
        {
            ViewBag.BusID = new SelectList(db.AvailableSeats, "BusID", "BusID");
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusID,BusNumber,busname,Capacity,Type,Source,Destination,Distance,DepartureTime,ArrivalTime,date")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Buses.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusID = new SelectList(db.AvailableSeats, "BusID", "BusID", bus.BusID);
            return View(bus);
        }

        // GET: Buses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusID = new SelectList(db.AvailableSeats, "BusID", "BusID", bus.BusID);
            return View(bus);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusID,BusNumber,busname,Capacity,Type,Source,Destination,Distance,DepartureTime,ArrivalTime,date")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusID = new SelectList(db.AvailableSeats, "BusID", "BusID", bus.BusID);
            return View(bus);
        }

        // GET: Buses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bus bus = db.Buses.Find(id);
            db.Buses.Remove(bus);
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
