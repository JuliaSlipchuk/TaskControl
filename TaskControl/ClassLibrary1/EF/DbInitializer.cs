using BusinessLogic.EF;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ClassLibrary1.EF
{
    public class DbInitializer : DropCreateDatabaseAlways<TrackerContext>
    {
        protected override void Seed(TrackerContext db)
        {
            var teams = new List<Team>
            {
                new Team { Id=1, Name="Team1", WorkingDirection="Programers on C#" },
                new Team { Id=2, Name="Team2", WorkingDirection="Database developers" },
                new Team { Id=3, Name="Team3", WorkingDirection="Designers" }
            };
            teams.ForEach(t => db.Teams.Add(t));
            var projects = new List<Project>
            {
                new Project { Id=1, Name="Project1", Status="Sheduled", Budget=500000, Customer="Firm1" },
                new Project { Id=2, Name="Project2", Status="In work", Budget=90000, Customer="Firm2" },
                new Project { Id=3, Name="Project3", Status="Completed", Budget=10000000, Customer="Firm1" },
            };
            projects.ForEach(p => db.Projects.Add(p));
            var workers = new List<Worker>
            {
                new Worker { Id=1, FirstName="Denis", LastName="Vinnichuk", Position="Designer", Phone="+38(067)-380-65-98", Email="vinni@gmail.com", Salary=30000, Сongestion=0.0, TeamId=1 },
                new Worker { Id=2, FirstName="Taras", LastName="Vons", Position=".NET developer", Phone="+38(068)-410-65-30", Email="taric@gmail.com", Salary=38000, Сongestion=50.0, TeamId=2 },
                new Worker { Id=3, FirstName="Oleg", LastName="Yanitskiy", Position="Database developer", Phone="+38(098)-320-00-96", Email="yanik@gmail.com", Salary=30000, Сongestion=20.0, TeamId=1 },
                new Worker { Id=4, FirstName="Katherina", LastName="Dolinchuk", Position="Perl developer", Phone="+38(096)-840-96-54", Email="katie@gmail.com", Salary=28000, Сongestion=80.0, TeamId=2 },
                new Worker { Id=5, FirstName="Bogdan", LastName="Loza", Position=".NET developer", Phone="+38(067)-650-94-58", Email="loza@gmail.com", Salary=35000, Сongestion=0.0, TeamId=3 }
            };
            workers.ForEach(w => db.Workers.Add(w));
            var tasks = new List<Task>
            {
                new Task { Id=1, Name="Create a circle", Description="Create a yellow cirle in the center of the site", Progress=100.0, Status="Done", Deadline=new DateTime(2020, 1, 1), WorkLoad=10.0, WorkerId=1, ProjectId=1 },
                new Task { Id=2, Name="Write to file", Description="Write all user actions to file", Progress=30.0, Status="Not ready", Deadline=new DateTime(2020, 1, 5), WorkLoad=15.0, WorkerId=2, ProjectId=1 },
                new Task { Id=3, Name="Create database", Description="Create database for shop network", Progress=2.5, Status="Not ready", Deadline=new DateTime(2020, 1, 1), WorkLoad=80.0, WorkerId=3, ProjectId=2 },
                new Task { Id=4, Name="Script for parsing", Description="Write code that parse HTML page", Progress=20.5, Status="Not ready", Deadline=new DateTime(2020, 1, 10), WorkLoad=70.0, WorkerId=4, ProjectId=2 },
                new Task { Id=5, Name="Create entities", Description="Create entities for database \"ShopDB\"", Progress=100.0, Status="Done", Deadline=new DateTime(2020, 1, 1), WorkLoad=35.0, WorkerId=5, ProjectId=3 },
                new Task { Id=6, Name="Create interfaces", Description="Create interfaces for \"ShopDB\"", Progress=50.0, Status="Not ready", Deadline=new DateTime(2020, 1, 15), WorkLoad=35.0, WorkerId=5, ProjectId=3 },
                new Task { Id=7, Name="Create a logo", Description="Create a logotype for the site", Progress=80.0, Status="Not ready", Deadline=new DateTime(2020, 1, 4), WorkLoad=10.0, WorkerId=1, ProjectId=1 },
                new Task { Id=8, Name="Create a picture", Description="Create a picture of ducknouse", Progress=90.0, Status="Not ready", Deadline=new DateTime(2020, 1, 1), WorkLoad=10.0, WorkerId=1, ProjectId=1 },
                new Task { Id=9, Name="Forget perl", Description="Go to python from perl", Progress=0, Status="Not ready", Deadline=new DateTime(2020, 1, 10), WorkLoad=70.0, WorkerId=4, ProjectId=2 },
            };
            tasks.ForEach(t => db.Tasks.Add(t));
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
