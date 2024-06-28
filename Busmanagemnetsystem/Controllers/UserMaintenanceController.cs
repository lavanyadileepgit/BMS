using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Ensure this matches your actual namespace

namespace Busmanagemnetsystem.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public MaintenanceController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: Maintenance
        public ActionResult Index()
        {
            var maintenance = _context.Maintenances.ToList();
            return View(maintenance);
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
