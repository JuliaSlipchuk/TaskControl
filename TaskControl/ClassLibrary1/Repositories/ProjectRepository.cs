using BusinessLogic.EF;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        TrackerContext db = new TrackerContext();
        public List<Project> GetAllProjects()
        {
            return db.Projects.ToList();
        }
    }
}
