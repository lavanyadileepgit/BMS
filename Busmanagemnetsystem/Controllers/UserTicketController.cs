using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Ensure this matches your actual namespace

namespace Busmanagemnetsystem.Controllers
{
    public class UserTicketsController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public UserTicketsController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: Tickets
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int userID = Convert.ToInt32(Session["UserID"]);
            var tickets = _context.Tickets.Include(t => t.Bus).Include(t => t.User).Where(t => t.UserID == userID).ToList();
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
