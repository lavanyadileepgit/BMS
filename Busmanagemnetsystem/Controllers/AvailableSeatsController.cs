using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Busmanagemnetsystem.Controllers
{
    public class AvailableSeatsController : Controller
    {
        private BusmanagementsystemEntities db = new BusmanagementsystemEntities();

        // GET: AvailableSeats
        public ActionResult Index()
        {
            var availableSeats = db.AvailableSeats.Include(a => a.Bus);
            return View(availableSeats.ToList());
        }

        // GET: AvailableSeats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableSeat availableSeat = db.AvailableSeats.Find(id);
            if (availableSeat == null)
            {
                return HttpNotFound();
            }
            return View(availableSeat);
        }

        // GET: AvailableSeats/Create
        public ActionResult Create()
        {
            ViewBag.BusID = new SelectList(db.Buses, "BusID", "BusNumber");
            return View();
        }

        // POST: AvailableSeats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusID,TotalSeats,AvailableSeats")] AvailableSeat availableSeat)
        {
            if (ModelState.IsValid)
            {
                db.AvailableSeats.Add(availableSeat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusID = new SelectList(db.Buses, "BusID", "BusNumber", availableSeat.BusID);
            return View(availableSeat);
        }

        // GET: AvailableSeats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableSeat availableSeat = db.AvailableSeats.Find(id);
            if (availableSeat == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusID = new SelectList(db.Buses, "BusID", "BusNumber", availableSeat.BusID);
            return View(availableSeat);
        }

        // POST: AvailableSeats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusID,TotalSeats,AvailableSeats")] AvailableSeat availableSeat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availableSeat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusID = new SelectList(db.Buses, "BusID", "BusNumber", availableSeat.BusID);
            return View(availableSeat);
        }

        // GET: AvailableSeats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableSeat availableSeat = db.AvailableSeats.Find(id);
            if (availableSeat == null)
            {
                return HttpNotFound();
            }
            return View(availableSeat);
        }

        // POST: AvailableSeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvailableSeat availableSeat = db.AvailableSeats.Find(id);
            db.AvailableSeats.Remove(availableSeat);
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
