using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Busmanagemnetsystem.Controllers; // Make sure this matches your actual namespace

namespace BMS.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly BusmanagementsystemEntities _context;

        public FeedbacksController()
        {
            _context = new BusmanagementsystemEntities();
        }

        // GET: Feedbacks
        public ActionResult Index()
        {
            var feedbacks = _context.Feedbacks.Include(f => f.User).ToList();
            return View(feedbacks);
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
