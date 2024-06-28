using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Ensure this matches your actual namespace

namespace Busmanagemnetsystem.Controllers
{
    public class BusController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public BusController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: Bus
        public ActionResult Index()
        {
            var buses = _context.Buses.ToList();
            return View(buses);
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
