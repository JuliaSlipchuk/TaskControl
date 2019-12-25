using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskControl.ViewModels;

namespace TaskControl.Mapping
{
    public class Mapper : IMapper
    {
        IProjectService ProjectService { get; set; }
        IWorkerService WorkerService { get; set; }
        ITaskService TaskService { get; set; }
        ITeamService TeamService { get; set; }
        MapperConfiguration config { get; set; }
        AutoMapper.IMapper mapper { get; set; }

        public Mapper(ITeamService teamService, IProjectService projectService, IWorkerService workerService, ITaskService taskService)
        {
            this.ProjectService = projectService;
            this.WorkerService = workerService;
            this.TaskService = taskService;
            this.TeamService = teamService;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamModel>();
                cfg.CreateMap<TeamModel, Team>();
                cfg.CreateMap<Project, ProjectModel>();
                cfg.CreateMap<ProjectModel, Project>();
                cfg.CreateMap<Worker, WorkerModel>();
                cfg.CreateMap<WorkerModel, Worker>();
                cfg.CreateMap<Task, TaskModel>();
                cfg.CreateMap<TaskModel, Task>();
                cfg.AllowNullCollections = true;
            });
            mapper = config.CreateMapper();
        }

        public List<TaskModel> GetNotReadyTaskModelsByTasks()
        {
            return mapper.Map<List<Task>, List<TaskModel>>(TaskService.GetNotReadyTasks());
        }
        public List<TaskModel> GetDoneTaskModelsByTasks()
        {
            return mapper.Map<List<Task>, List<TaskModel>>(TaskService.GetDoneTasks());
        }
        public TaskModel GetTaskModelByTaskName(string taskName)
        {
            return mapper.Map<Task, TaskModel>(TaskService.GetTaskByTaskName(taskName));
        }
        public List<WorkerModel> GetWorkerModelByLastName(string lastName, int teamId)
        {
            return mapper.Map<List<Worker>, List<WorkerModel>>(WorkerService.GetWorkerByLastName(lastName, teamId));
        }
        public List<ProjectModel> GetAllProjectModels()
        {
            return mapper.Map<List<Project>, List<ProjectModel>>(ProjectService.GetAllProjects());
        }
        public Task GetTaskByTaskModel(TaskModel model)
        {
            return mapper.Map<TaskModel, Task>(model);
        }
        public TaskModel GetTaskModelById(int? id)
        {
            return mapper.Map<Task, TaskModel>(TaskService.GetTaskById(id));
        }
        public List<TaskModel> GetTaskModelsByTasks()
        {
            return mapper.Map<List<Task>, List<TaskModel>>(TaskService.GetAllTasks());
        }
        public Worker GetWorkerByWorkerModel(WorkerModel model)
        {
            return mapper.Map<WorkerModel, Worker>(model);
        }
        public WorkerModel GetWorkerModelById(int? id)
        {
            return mapper.Map<Worker, WorkerModel>(WorkerService.GetWorkerById(id));
        }
        public List<TeamModel> GetAllTeamModelsByTeams()
        {
            var models = mapper.Map<List<Team>, List<TeamModel>>(TeamService.GetAllTeams());
            return models;
        }
        public List<WorkerModel> GetAllWorkersByTeam(int? id)
        {
            var models = mapper.Map<List<Worker>, List<WorkerModel>>(TeamService.GetAllWorkersByTeam(id));
            return models;
        }

        public Team GetTeamByTeamModel(TeamModel team)
        {
            return mapper.Map<TeamModel, Team>(team);
        }
    }
}