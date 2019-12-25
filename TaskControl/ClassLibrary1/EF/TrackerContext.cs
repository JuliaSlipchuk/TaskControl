using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using BusinessLogic.Entities;
using ClassLibrary1.Interfaces;

namespace BusinessLogic.EF
{
    public class TrackerContext : DbContext, ITrackerContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        static TrackerContext() { }

        public TrackerContext()
            : base("DefaultConnection") { }
    }
}
