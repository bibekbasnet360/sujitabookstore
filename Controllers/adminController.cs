using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sujitabookstore;

namespace sujitabookstore.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(usertable usr)
        {
            //get username and password from the user
            //check it against the database usertable
            sujitabooksEntities dbObject = new sujitabooksEntities();
            var checkUser = dbObject.usertables.Where(l => l.u_name.Equals(usr.u_name) && l.u_password.Equals(usr.u_password)).FirstOrDefault();
            if (checkUser != null)
            {
                var loggeduser = dbObject.usertables.Where(l => l.u_name.Equals(usr.u_name)).FirstOrDefault();

                Session["u_name"] = loggeduser.u_name.ToString();
                Session["u_id"] = loggeduser.u_id.ToString();



                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";
            }
            return View();

        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}