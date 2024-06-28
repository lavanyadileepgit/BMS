using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Busmanagemnetsystem.Controllers
{
    public class UserMainPageController : Controller
    {
         public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Index(User model)
            {
                if (ModelState.IsValid)
                {
                    Session["UserID"] = model.UserID;
                    return RedirectToAction("UserDashboard");
                }

                return View(model);
            }

            public ActionResult UserDashboard()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            public ActionResult UserFeedbacks()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            public ActionResult UserAvailableSeats()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            public ActionResult UserProfiles()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            public ActionResult Maintenance()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            public ActionResult Bus()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            public ActionResult Payments()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            public ActionResult Tickets()
            {
                int? userId = (int?)Session["UserID"];
                if (userId == null)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
        }
    }

