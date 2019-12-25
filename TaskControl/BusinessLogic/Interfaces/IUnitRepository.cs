using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    interface IUnitRepository
    {
        IProjectRepository projectRepository { get; set; }
        IWorkerRepository workerRepository { get; set; }
        ITaskRepository taskRepository { get; set; }
    }
}
