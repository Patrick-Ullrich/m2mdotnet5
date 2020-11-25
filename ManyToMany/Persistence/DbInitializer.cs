using ManyToMany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Persistence
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(StreamingContext context)
        {
            context.Database.EnsureCreated();

            if(context.Streamers.Any())
            {
                var streamersWithSubscribers = context.Streamers.Where(streamer => streamer.Subscribers.Any(sub => sub.Age > 18)).ToList();

                foreach (var streamer in streamersWithSubscribers)
                {
                    Console.WriteLine($"Streamer: {streamer.Name}");
                }

                var subscribersMonths = context.Subscribers.Where(sub => sub.Subscriptions.Any(x => x.MonthsSubscribed > 3)).ToList();
                foreach (var sub in subscribersMonths)
                {
                    Console.WriteLine($"Subscriber: {sub.Name}");
                }

                return;
            }

            var streamer1 = new Streamer { Name = "Patrick" };
            var streamer2 = new Streamer { Name = "Ryan" };

            var streamers = new Streamer[]
            {
                streamer1,
                streamer2,
                new Streamer { Name = "Streamer3" },
            };
            context.AddRange(streamers);
            context.SaveChanges();

            var subscriber1 = new Subscriber { Name = "Aaron", Age = 20, Subscriptions = new List<Subscription> { new Subscription { Streamer = streamer1, MonthsSubscribed = 6 } }, Streamers = new List<Streamer> { streamer2 } };
            var subscriber2 = new Subscriber { Name = "Becca", Age = 16, Streamers = new List<Streamer> { streamer1, streamer2 } };
            var subscribers = new Subscriber[]
            {
                subscriber1,
                subscriber2,
                new Subscriber { Name = "Carol", Age = 1},
            };
            context.AddRange(subscribers);
            context.SaveChanges();

            //var subscriptions = new Subscription[]
            //{
            //    new Subscription {
            //        Streamer = streamer1,
            //        Subscriber = subscriber1,
            //        MonthsSubscribed = 2
            //    },
            //    new Subscription {
            //        Streamer = streamer1,
            //        Subscriber = subscriber2,
            //        MonthsSubscribed = 6
            //    },
            //    new Subscription {
            //        Streamer = streamer2,
            //        Subscriber = subscriber1,
            //        MonthsSubscribed = 2
            //    },
            //};


        }
    }
}
