using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskControl.ViewModels;

namespace TaskControl.Mapping
{
    public interface IMapper
    {
        List<TaskModel> GetDoneTaskModelsByTasks();
        List<TaskModel> GetNotReadyTaskModelsByTasks();
        TaskModel GetTaskModelByTaskName(string taskName);
        List<WorkerModel> GetWorkerModelByLastName(string lastName, int teamId);
        List<ProjectModel> GetAllProjectModels();
        BusinessLogic.Entities.Task GetTaskByTaskModel(TaskModel model);
        TaskModel GetTaskModelById(int? id);
        List<TaskModel> GetTaskModelsByTasks();
        WorkerModel GetWorkerModelById(int? id);
        List<WorkerModel> GetAllWorkersByTeam(int? id);
        List<TeamModel> GetAllTeamModelsByTeams();
        Worker GetWorkerByWorkerModel(WorkerModel model);
        Team GetTeamByTeamModel(TeamModel model);
    }
}
