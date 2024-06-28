using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Busmanagemnetsystem.Controllers
{
    public class UserFeedbacksController : Controller
    {
        private BusmanagementsystemEntities db = new BusmanagementsystemEntities();

        // GET: UserFeedbacks
        public async Task<ActionResult> Index()
        {
            var userId = (int)Session["UserID"];
            var feedbacks = db.Feedbacks.Where(f => f.UserID == userId);
            return View(await feedbacks.ToListAsync());
        }

        // GET: UserFeedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserFeedbacks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FeedbackID,Comments,Rating")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                // Retrieve UserID from session
                var userId = (int)Session["UserID"];
                feedback.UserID = userId;

                db.Feedbacks.Add(feedback);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "thankyou");
            }

            return View(feedback);
        }

        // GET: UserFeedbacks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = await db.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: UserFeedbacks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FeedbackID,Comments,Rating")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
