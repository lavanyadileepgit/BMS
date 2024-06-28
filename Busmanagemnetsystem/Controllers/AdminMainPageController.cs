using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Busmanagemnetsystem.Controllers
{
    public class AdminMainPageController : Controller
    {
        // GET: AdminMainPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buses()
        {
            return View();
        }

        public ActionResult Drivers()
        {
            return View();
        }

        public ActionResult Maintenances()
        {
            return View();
        }

        public ActionResult AvailableSeats()
        {
            return View();
        }

        public ActionResult Bookings()
        {
            return View();
        }

        public ActionResult BookingHistories()
        {
            return View();
        }

        public ActionResult Feedbacks()
        {
            return View();
        }

        public ActionResult Payments()
        {
            return View();
        }

        public ActionResult Tickets()
        {
            return View();
        }
    }
}
