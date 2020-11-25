using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
    public class Streamer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subscriber> Subscribers{ get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
