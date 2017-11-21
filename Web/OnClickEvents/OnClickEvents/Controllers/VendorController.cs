using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnClickEvents.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult RegisterVenue() {
            return View();
        }

        public ActionResult AddFood()
        {
            return View();
        }
    }
}