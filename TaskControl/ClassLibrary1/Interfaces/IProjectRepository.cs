using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> GetAllProjects();
    }
}
