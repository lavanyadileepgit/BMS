using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Make sure this matches your actual namespace

namespace Busmanagemnetsystem.Controllers
{
    public class BookingHistoriesController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public BookingHistoriesController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: BookingHistories
        public ActionResult Index()
        {
            var bookingHistories = _context.BookingHistories.Include(b => b.Ticket).Include(b => b.User).ToList();
            return View(bookingHistories);
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
