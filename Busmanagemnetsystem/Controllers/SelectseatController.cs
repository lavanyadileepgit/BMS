using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busmanagementsystem.Controllers;
using Busmanagemnetsystem.Controllers;

namespace Busmanagementsystem.Controllers
{
    public class SelectseatController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public SelectseatController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: Selectseat
        public ActionResult Index(int busId)
        {
            var availableSeats = GetAvailableSeatsForBus(busId);
            ViewBag.BusID = busId;
            return View(availableSeats);
        }

        private IEnumerable<Seat> GetAvailableSeatsForBus(int busId)
        {
            var seats = _context.Seats
                .Where(s => s.BusID == busId && s.IsAvailable)
                .ToList();

            return seats;
        }

        [HttpPost]
        public ActionResult BookSeats(int busId, List<int> seatNumbers)
        {
            try
            {
                // Ensure Session["UserID"] is not null
                if (!(Session["UserID"] is int userId))
                {
                    return Json(new { success = false, message = "User session expired." });
                }

                var bus = _context.Buses.FirstOrDefault(b => b.BusID == busId);
                if (bus == null)
                {
                    return Json(new { success = false, message = "Invalid Bus ID." });
                }

                var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
                if (user == null)
                {
                    return Json(new { success = false, message = "User not found." });
                }

                if (bus.fare == null)
                {
                    return Json(new { success = false, message = "Bus fare information is missing." });
                }

                var username = user.Username;
                int numberOfSeatsBooked = seatNumbers.Count;
                decimal fare = bus.fare.HasValue ? bus.fare.Value * numberOfSeatsBooked : 0;

                Ticket ticket = new Ticket
                {
                    UserID = userId,
                    PassengerName = username,
                    SeatNumber = string.Join(", ", seatNumbers.Select(s => s.ToString())),
                    NumberOfSeats = numberOfSeatsBooked,
                    BusID = busId,
                    BusName = bus.BusName,
                    BookingDate = DateTime.Now,
                    Fare = fare
                };
                _context.Tickets.Add(ticket);

                // Create booking entries
                foreach (int seatNumber in seatNumbers)
                {
                    var seat = _context.Seats.FirstOrDefault(s => s.BusID == busId && s.SeatID == seatNumber);
                    if (seat != null && seat.IsAvailable)
                    {
                        seat.IsAvailable = false;

                        Booking booking = new Booking
                        {
                            UserID = userId,
                            From_Station = bus.Source,
                            To_Station = bus.Destination,
                            Date = DateTime.Now,
                            BusID = busId,
                            SeatNumber = seatNumber.ToString()
                        };
                        _context.Bookings.Add(booking);
                    }
                }

                var availableSeat = _context.AvailableSeats.FirstOrDefault(a => a.BusID == busId);
                if (availableSeat != null)
                {
                    availableSeat.AvailableSeats = (availableSeat.AvailableSeats ?? availableSeat.TotalSeats) - seatNumbers.Count;
                }

                _context.SaveChanges();

                BookingHistory bookingHistory = new BookingHistory
                {
                    UserID = userId,
                    TicketID = ticket.TicketID,
                    BookingDate = DateTime.Now,
                    Status = "Booked"
                };
                _context.BookingHistories.Add(bookingHistory);

                _context.SaveChanges();

                return Json(new { success = true, message = "Seats and ticket booked successfully.", ticketId = ticket.TicketID });
            }
            catch (Exception ex)
            {
                // Log the error details for further investigation
                Console.WriteLine("Error booking seats and ticket: " + ex.Message);
                return Json(new { success = false, message = "Error booking seats and ticket: " + ex.Message });
            }
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
