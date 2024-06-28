using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Busmanagemnetsystem.Controllers
{
    public class LoginController : Controller
    {
        private BusmanagementsystemEntities db = new BusmanagementsystemEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string SelectedRole, string Username, string Password)
        {
            if (SelectedRole == "Admin")
            {
                if (Username == "admin" && Password == "admin")
                {
                    return RedirectToAction("Index", "AdminMainpage");
                }
                else
                {
                    ViewBag.Message = "Invalid admin credentials.";
                    ViewBag.Color = "red";
                    return View();
                }
            }
            else if (SelectedRole == "User")
            {
                var user = db.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    Session["UserID"] = user.UserID;
                    return RedirectToAction("Index", "UserMainpage");
                }
                else
                {
                    ViewBag.Message = "Invalid user credentials.";
                    ViewBag.Color = "red";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Please select a role.";
                ViewBag.Color = "red";
                return View();
            }
        }
    }
}
