using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Customers()
        {
            // Ideally, you would fetch your customers from a database
            // For demonstration, we'll return a view directly
            return View();
        }

        public ActionResult Services()
        {
            // Similarly, fetch services from a database if applicable
            // For now, we return a view directly
            return View();
        }
    }
}

