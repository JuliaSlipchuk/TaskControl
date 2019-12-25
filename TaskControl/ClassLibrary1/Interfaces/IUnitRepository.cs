using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IUnitRepository
    {
        ITeamRepository teamRepository { get; set; }
        IProjectRepository projectRepository { get; set; }
        IWorkerRepository workerRepository { get; set; }
        ITaskRepository taskRepository { get; set; }

        ITrackerContext trackerContext { get; set; }
    }
}
