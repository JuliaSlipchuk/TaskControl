using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface ITrackerContext
    {
        DbSet<Team> Teams { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<BusinessLogic.Entities.Task> Tasks { get; set; }
       // void SaveChanges();
    }
}
