using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Giftstarter.Controllers
{
    using Domain;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPostAttribute]
        public ActionResult Login(string username, string password)
        {
            return RedirectToAction("Wishlist");
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

        public ActionResult AddWishlistItem(AddWishlistItem model)
        {
            State.Instance.Wishlists[new User("James")].Add(new WishedItem
            {
                Name = model.Name,
                Link = model.Link,
                Price = model.Price,
                Contributors = new Dictionary<User, decimal>()
            });

            return RedirectToAction("Wishlist");
        }
    }
}
