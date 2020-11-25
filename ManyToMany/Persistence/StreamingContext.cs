using ManyToMany.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Persistence
{
    public class StreamingContext : DbContext
    {
        public StreamingContext(DbContextOptions<StreamingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(s => s.Subscribers)
                .WithMany(s => s.Streamers)
                .UsingEntity<Subscription>(
                    j => j.HasOne(s => s.Subscriber).WithMany(s => s.Subscriptions),
                    j => j.HasOne(s => s.Streamer).WithMany(s => s.Subscriptions));
        }

        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
