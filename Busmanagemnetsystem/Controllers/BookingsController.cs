using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Ensure this matches your actual namespace

namespace Busmanagemnetsystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public BookingController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // POST: Booking/BookSeats
        [HttpPost]
        public ActionResult BookSeats(List<int> seatNumbers)
        {
            if (seatNumbers == null || seatNumbers.Count == 0)
            {
                return Json(new { success = false, message = "No seats selected." });
            }

            // Assuming the seats are available and can be booked
            foreach (int seatNumber in seatNumbers)
            {
                // Add logic to book the seat (e.g., add to booking table)
                // For simplicity, let's just update the AvailableSeats status to 'Booked'
                var seat = _context.AvailableSeats.FirstOrDefault(a => a.AvailableSeats == seatNumber);
                if (seat != null)
                {
                   // seat.Status = "Booked";
                    _context.SaveChanges();
                }
            }

            return Json(new { success = true, message = "Seats booked successfully." });
        }

        // GET: Booking/BookingSuccessful
        public ActionResult BookingSuccessful()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
