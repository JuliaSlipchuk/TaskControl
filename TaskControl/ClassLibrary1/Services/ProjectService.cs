using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class ProjectService : IProjectService
    {
        IUnitRepository unitRepository;

        public ProjectService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public List<Project> GetAllProjects()
        {
            return unitRepository.projectRepository.GetAllProjects();
        }
    }
}
