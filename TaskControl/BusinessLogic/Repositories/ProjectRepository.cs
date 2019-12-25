using BusinessLogic.EF;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Repositories
{
    class ProjectRepository : IProjectRepository
    {
        TrackerContext db;
        public string GetStatusProjectImplem(int? id)
        {
            string status = null;
            if (id != null)
            {
                Project project = db.Projects.Where(p => p.Id == id).ToList()[0];
                if (project != null)
                {
                    status = project.Status;
                }
            }
            return status;
        }
    }
}
