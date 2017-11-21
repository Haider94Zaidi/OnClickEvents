using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnClickEvents.Controllers
{
    public class WeddingController : Controller
    {
        // GET: Wedding
        public ActionResult Index()
        {
            ViewBag.EventType = "Wedding";
            return View();
        }


        public ActionResult Venues() {
            return View();
        }
    }
}