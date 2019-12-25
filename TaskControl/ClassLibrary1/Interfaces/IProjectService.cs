using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
    }
}
