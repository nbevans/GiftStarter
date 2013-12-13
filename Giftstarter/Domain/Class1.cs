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
                            Contributors = new Dictionary<User, decimal>() {{nathan, 2}}
                        }
                    }
                },
                {
                    emma,
                    new List<WishedItem>()
                    {
                        new WishedItem()
                        {
                            Name = "Smiley Juggling Balls",
                            Link = "http://www.amazon.co.uk/Pack-Smiley-Juggling-Balls-Kick/dp/B00B8XJAOA/ref=sr_1_3?s=kitchen&ie=UTF8&qid=1386936910&sr=1-3&keywords=juggling+balls",
                            Price = 6m,
                            Contributors = new Dictionary<User, decimal>()
                        }
                    }
                },
                {
                    nathan,
                    new List<WishedItem>()
                    {
                        new WishedItem()
                        {
                            Name = "iPad Pedestal Stand with Roll Holder",
                            Link = "http://www.amazon.com/CTA-Digital-Pedestal-Stand-Holder/dp/B00AQT653G/ref=pd_rhf_se_p_d_3",
                            Price = 41.25m,
                            Contributors = new Dictionary<User, decimal>() {{emma, 5}, {simon, 3}}
                        }
                    }
                },
                {
                    simon,
                    new List<WishedItem>()
                    {
                        new WishedItem()
                        {
                            Name = "Emy fancy dress costume",
                            Link = "http://www.amazon.co.uk/fancy-dress-Ostrich-costume-novelty/dp/B00DOZQV8S/ref=sr_1_1?ie=UTF8&qid=1386935564&sr=8-1&keywords=emu+costume",
                            Price = 61.9m,
                            Contributors = new Dictionary<User, decimal>()
                        },
                        new WishedItem()
                        {
                            Name = "PHP 5 For Dummies",
                            Link = "http://www.amazon.co.uk/PHP-For-Dummies-Janet-Valade/dp/0764541668/ref=sr_1_4?ie=UTF8&qid=1386936068&sr=8-4&keywords=php+for+dummies",
                            Price = 19.99m,
                            Contributors = new Dictionary<User, decimal>()
                        }
                    }
                }
            };
            Users = new List<User> { james, nathan, emma, simon };
        }
    }
}