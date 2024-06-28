using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Ensure this matches your actual namespace

namespace Busmanagemnetsystem.Controllers
{
    public class UserAvailableseatsController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public UserAvailableseatsController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: AvailableSeats
        public ActionResult Index(int busId)
        {
            var availableSeats = _context.AvailableSeats.Where(a => a.BusID == busId).ToList();
            return View(availableSeats);
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
