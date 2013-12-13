using System;
using System.Collections.Generic;

namespace Giftstarter.Domain
{
    using System.Linq;

    public class WishedItem
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public IDictionary<User, decimal> Contributors { get; set; }

        public decimal Contribution()
        {
            return Contributors.Values.Sum();
        }

        public WishedItem()
        {
            Contributors = new Dictionary<User, decimal>();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }

    public class State
    {
        public IDictionary<User, IList<WishedItem>> Wishlists { get; set; }
        public IList<User> Users { get; private set; }

        public State()
        {
            var james = new User("James");
            var nathan = new User("Nathan");
            var emma = new User("Emma");
            var simon = new User("Simon");
            Wishlists = new Dictionary<User, IList<WishedItem>>()
            {
                {
                    james,
                    new List<WishedItem>()
                    {
                        new WishedItem
                        {
                            Name = "Pancake Pen",
                            Link = "http://www.amazon.com/Tovolo-28015-Pancake-Pen/dp/B0036DD9OW   ",
                            Price = 5.99m,
                            Contributors = new Dictionary<User, decimal>() { { nathan, 2 } }
                        }
                    }
                }
            };
            Users = new List<User> { james, nathan, emma, simon };
        }
    }
}