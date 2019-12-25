using BusinessLogic.Interfaces;
using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        public ITeamRepository teamRepository { get; set; }
        public IProjectRepository projectRepository { get; set; }
        public IWorkerRepository workerRepository { get; set; }
        public ITaskRepository taskRepository { get; set; }
        public ITrackerContext trackerContext { get; set; }

        public UnitRepository(ITeamRepository teamRepository, IProjectRepository projectRepository, IWorkerRepository workerRepository, ITaskRepository taskRepository, ITrackerContext trackerContext)
        {
            this.teamRepository =teamRepository;
            this.projectRepository = projectRepository;
            this.workerRepository = workerRepository;
            this.taskRepository = taskRepository;
            this.trackerContext = trackerContext;
        }
    }
}
