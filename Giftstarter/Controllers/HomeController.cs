using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Giftstarter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Wishlist()
        {
            return View();
        }

        public ActionResult Friends()
        {
            return View();
        }

        public ActionResult Friend(string name)
        {
            return View();
        }
    }
}
