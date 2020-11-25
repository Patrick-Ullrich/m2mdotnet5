﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
    public class Subscription
    {
        public Streamer Streamer { get; set; }
        public Subscriber Subscriber { get; set; }
        public int MonthsSubscribed { get; set; }
    }
}


public class Subscriber
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public ICollection<Streamer> Streamers { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; }
}

public class Streamer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Subscriber> Subscribers { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; }
}

public class Subscription
{
    public Streamer Streamer { get; set; }
    public Subscriber Subscriber { get; set; }
    public int MonthsSubscribed { get; set; }
}