using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using BusinessLogic.Entities;

namespace BusinessLogic.EF
{
    class TrackerContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        static TrackerContext()
        {
            Database.SetInitializer<TrackerContext>(new TrackerDbInitializer());
        }
        public TrackerContext(string connectionString)
            : base(connectionString) { }
    }
    class TrackerDbInitializer : DropCreateDatabaseAlways<TrackerContext>
    {
        protected override void Seed(TrackerContext db)
        {
            var teams = new List<Team>
            {
                new Team { Name="Team1", WorkingDirection="Programers on C#" },
                new Team { Name="Team2", WorkingDirection="Database developers" },
                new Team { Name="Team3", WorkingDirection="Designers" }
            };
            teams.ForEach(t => db.Teams.Add(t));
            var projects = new List<Project>
            {
                new Project { Name="Project1", Status="Sheduled", Budget=500000, Customer="Firm1" },
                new Project { Name="Project2", Status="In work", Budget=90000, Customer="Firm2" },
                new Project { Name="Project3", Status="Completed", Budget=10000000, Customer="Firm1" },
            };
            projects.ForEach(p => db.Projects.Add(p));
            var workers = new List<Worker>
            {
                new Worker { FirstName="Denis", LastName="Vinnichuk", Position="Designer", Phone="+380673806598", Email="vinni@gmail.com", Salary=30000, Сongestion=0.0, TeamId=1 },
                new Worker { FirstName="Taras", LastName="Vons", Position=".NET developer", Phone="+380684106530", Email="taric@gmail.com", Salary=38000, Сongestion=50.0, TeamId=2 },
                new Worker { FirstName="Oleg", LastName="Yanitskiy", Position="Database developer", Phone="+380983200096", Email="yanik@gmail.com", Salary=30000, Сongestion=20.0, TeamId=1 },
                new Worker { FirstName="Katherina", LastName="Dolinchuk", Position="Perl developer", Phone="+380968409654", Email="katie@gmail.com", Salary=28000, Сongestion=80.0, TeamId=2 },
                new Worker { FirstName="Bogdan", LastName="Loza", Position=".NET developer", Phone="+380676509458", Email="loza@gmail.com", Salary=35000, Сongestion=0.0, TeamId=3 }
            };
            workers.ForEach(w => db.Workers.Add(w));
            var tasks = new List<Task>
            {
                new Task { Name="Create a circle", Description="Create a yellow cirle in the center of the site", Progress=100.0, Status="Done", Deadline=new DateTime(2020, 1, 1), WordLoad=10.0, WorkerId=1, ProjectId=1 },
                new Task { Name="Write to file", Description="Write all user actions to file", Progress=30.0, Status="Not ready", Deadline=new DateTime(2020, 1, 5), WordLoad=15.0, WorkerId=2, ProjectId=1 },
                new Task { Name="Create database", Description="Create database for shop network", Progress=2.5, Status="Not ready", Deadline=new DateTime(2020, 1, 1), WordLoad=80.0, WorkerId=3, ProjectId=2 },
                new Task { Name="Script for parsing", Description="Write code that parse HTML page", Progress=20.5, Status="Not ready", Deadline=new DateTime(2020, 1, 10), WordLoad=70.0, WorkerId=4, ProjectId=2 },
                new Task { Name="Create entities", Description="Create entities for database \"ShopDB\"", Progress=100.0, Status="Done", Deadline=new DateTime(2020, 1, 1), WordLoad=35.0, WorkerId=5, ProjectId=3 },
                new Task { Name="Create interfaces", Description="Create interfaces for \"ShopDB\"", Progress=50.0, Status="Not ready", Deadline=new DateTime(2020, 1, 15), WordLoad=35.0, WorkerId=5, ProjectId=3 },
                new Task { Name="Create a logo", Description="Create a logotype for the site", Progress=80.0, Status="Not ready", Deadline=new DateTime(2020, 1, 4), WordLoad=10.0, WorkerId=1, ProjectId=1 },
                new Task { Name="Create a picture", Description="Create a picture of ducknouse", Progress=90.0, Status="Not ready", Deadline=new DateTime(2020, 1, 1), WordLoad=10.0, WorkerId=1, ProjectId=1 },
                new Task { Name="Forget perl", Description="Go to python from perl", Progress=0, Status="Not ready", Deadline=new DateTime(2020, 1, 10), WordLoad=70.0, WorkerId=4, ProjectId=2 },
            };

            db.SaveChanges();
            base.Seed(db);
        }
    }
}
