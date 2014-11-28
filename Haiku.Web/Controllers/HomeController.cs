using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haiku.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Meeting your unrhymed, syllabic poetry needs.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What's it all about then?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Keeping in touch with us.";

            return View();
        }
    }
}
