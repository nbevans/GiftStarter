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

        public decimal Progress()
        {
            var x = Contribution()/Price*100;
            return Math.Min(100, x);
        }

        public WishedItem()
        {
            Contributors = new Dictionary<User, decimal>();
        }
    }

    public class User : IComparable<User>, IEquatable<User>
    {
        public string Name { get; set; }
        public string Mugshot { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public int CompareTo(User other)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(Name, other.Name);
        }

        public bool Equals(User other)
        {
            return StringComparer.OrdinalIgnoreCase.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
        }
    }

    public class State
    {
        public IDictionary<User, IList<WishedItem>> Wishlists { get; set; }
        public IList<User> Users { get; private set; }
        public static readonly State Instance = new State();

        private State()
        {
            var james = new User("James");
            var nathan = new User("Nathan");
            var emma = new User("Emma");
            var simon = new User("Simon");
            var sven = new User("Sven");
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
                            Contributors = new Dictionary<User, decimal>() {{simon, 1}}
                        },
                        new WishedItem()
                        {
                            Name = "Hula Hoops",
                            Link = "http://www.amazon.co.uk/Hula-hoops-bundle-4x600mm-03276/dp/B000YETBUM/ref=sr_1_9?ie=UTF8&qid=1386955328&sr=8-9&keywords=hula+hoop",
                            Price = 8.4m,
                            Contributors = new Dictionary<User, decimal>() {{nathan, 2}}
                        },
                        new WishedItem()
                        {
                            Name = "Jenga",
                            Link = "http://www.amazon.co.uk/Hasbro-71367-Jenga/dp/B00004XQW9/ref=sr_1_4?ie=UTF8&qid=1386955463&sr=8-4&keywords=jenga",
                            Price = 17.99m,
                            Contributors = new Dictionary<User, decimal>() {{sven, 5}, {james, 12}}
                        },
                        new WishedItem()
                        {
                            Name = "Nerf Gun",
                            Link = "http://www.amazon.co.uk/Nerf-N-Strike-Elite-Strongarm-Blaster/dp/B009NFH7CC/ref=sr_1_1?ie=UTF8&qid=1386955576&sr=8-1&keywords=nerf+gun", 
                            Price = 11.99m,
                            Contributors = new Dictionary<User, decimal>() {{simon, 8}}
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
                        },
                        new WishedItem()
                        {
                            Name = "COBOL For Dummies",
                            Link = "http://www.amazon.co.uk/Cobol-For-Dummies-Arthur-Griffith/dp/0764502980/ref=sr_1_1?ie=UTF8&qid=1386948411&sr=8-1&keywords=cobol+for+dummies",
                            Price = 69.74m,
                            Contributors = new Dictionary<User, decimal>() {{emma, 10}, {james, 20}, {simon, 30}}
                        }
                    }
                },
                {
                    simon,
                    new List<WishedItem>()
                    {
                        new WishedItem()
                        {
                            Name = "Emu fancy dress costume",
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
                },
                {
                    sven,
                    new List<WishedItem>()
                }
            };
            Users = new List<User> { james, nathan, emma, simon, sven };
        }
    }
}