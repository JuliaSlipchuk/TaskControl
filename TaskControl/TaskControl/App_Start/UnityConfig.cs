using BusinessLogic.EF;
using BusinessLogic.Interfaces;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using System.Web.Mvc;
using TaskControl.Controllers;
using TaskControl.Mapping;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace TaskControl
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ITeamService, TeamService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IWorkerService, WorkerService>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<ITrackerContext, TrackerContext>();
            container.RegisterType<IMapper, Mapper>();
            container.RegisterType<ITeamRepository, TeamRepository>();
            container.RegisterType<IProjectRepository, ProjectRepository>();
            container.RegisterType<IWorkerRepository, WorkerRepository>();
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<IUnitRepository, UnitRepository>();

            //container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<UsersAdminController>(new InjectionConstructor());

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}