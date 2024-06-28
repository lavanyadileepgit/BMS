using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Ensure this matches your actual namespace

namespace Busmanagemnetsystem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public TicketsController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = _context.Tickets.Include(t => t.Bus).Include(t => t.User).ToList();
            return View(tickets);
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
