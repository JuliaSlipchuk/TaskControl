using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    class ProjectService : IProjectService
    {
        IUnitRepository unitRepository;

        public ProjectService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public string GetStatusProjectImplem(int? id)
        {
            return this.unitRepository.projectRepository.GetStatusProjectImplem(id);
        }
    }
}
