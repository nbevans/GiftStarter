using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Giftstarter.Domain;

namespace Giftstarter.Models
{
    public class AddWishlistItem
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
    }

    public class Friend
    {
        public User User { get; set; }
    }
}