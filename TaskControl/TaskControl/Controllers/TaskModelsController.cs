using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.EF;
using BusinessLogic.Interfaces;
using ClassLibrary1.Interfaces;
using TaskControl.Mapping;
using TaskControl.ViewModels;

namespace TaskControl.Controllers
{
    public class TaskModelsController : Controller
    {
        private TrackerContext db = new TrackerContext();
        IWorkerService workerService { get; set; }
        ITaskService taskService { get; set; }
        IProjectService projectService { get; set; }

        IMapper Mapper { get; set; }

        public TaskModelsController(IWorkerService workerService, ITaskService taskService, IProjectService projectService, IMapper mapperControl)
        {
            this.workerService = workerService;
            this.taskService = taskService;
            this.projectService = projectService;
            Mapper = mapperControl;
        }

        // GET: TaskModels
        public ActionResult GetAllTasks()
        {
            if (User.Identity.IsAuthenticated)
            {
                string UserName = User.Identity.Name;
                List<TaskModel> taskModels = Mapper.GetTaskModelsByTasks();
                return View(taskModels.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TaskModels/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TaskModel model = Mapper.GetTaskModelById(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TaskModels/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.WorkerId = new SelectList(db.Workers, "Id", "LastName");
                ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TaskModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Progress,Status,Deadline,WorkLoad,WorkerId,ProjectId")] TaskModel taskModel)
        {
            WorkerModel worker = Mapper.GetWorkerModelById(taskModel.WorkerId);
            if (ModelState.IsValid && worker.Сongestion + taskModel.WorkLoad <= 100 && taskModel.Progress >= 0.0 && taskModel.Progress <= 100.0 && taskModel.Deadline >= DateTime.Now && taskModel.WorkLoad >= 1 && taskModel.WorkLoad <= 100 && (taskModel.Status == "Done" || taskModel.Status == "Not ready"))
            {
                worker.Сongestion += taskModel.WorkLoad;
                workerService.EditWorker(Mapper.GetWorkerByWorkerModel(worker));
                var newTask = Mapper.GetTaskByTaskModel(taskModel);
                taskService.CreateTask(newTask);
                return RedirectToAction("GetAllTasks");
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "LastName");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View(taskModel);
        }

        // GET: TaskModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TaskModel taskModel = Mapper.GetTaskModelById(id);
                if (taskModel == null)
                {
                    return HttpNotFound();
                }
                ViewBag.WorkerId = new SelectList(db.Workers, "Id", "LastName");
                ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
                return View(taskModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TaskModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Progress,Status,Deadline,WorkLoad,WorkerId,ProjectId")] TaskModel taskModel)
        {
            WorkerModel worker = Mapper.GetWorkerModelById(taskModel.WorkerId);
            if (ModelState.IsValid && worker.Сongestion + taskModel.WorkLoad <= 100 && taskModel.WorkLoad >= 1 && taskModel.WorkLoad <= 100 && taskModel.Progress >= 0.0 && taskModel.Progress <= 100.0 && taskModel.Deadline >= DateTime.Now && (taskModel.Status == "Done" || taskModel.Status == "Not ready"))
            {
                worker.Сongestion += taskModel.WorkLoad;
                workerService.EditWorker(Mapper.GetWorkerByWorkerModel(worker));
                var task = Mapper.GetTaskByTaskModel(taskModel);
                taskService.EditTask(task);
                return RedirectToAction("GetAllTasks");
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "LastName");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View(taskModel);
        }

        // GET: TaskModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var taskModel = Mapper.GetTaskModelById(id);
                if (taskModel == null)
                {
                    return HttpNotFound();
                }
                return View(taskModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: TaskModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskModel taskModel = Mapper.GetTaskModelById(id);
            WorkerModel worker = Mapper.GetWorkerModelById(taskModel.WorkerId);
            worker.Сongestion -= taskModel.WorkLoad;
            workerService.EditWorker(Mapper.GetWorkerByWorkerModel(worker));
            var task = Mapper.GetTaskByTaskModel(taskModel);
            taskService.DeleteTask(task.Id);
            return RedirectToAction("GetAllTasks");
        }
        public ActionResult GetWorkerThisTask(string taskName)
        {
            if (User.Identity.IsAuthenticated)
            {
                TaskModel task = Mapper.GetTaskModelByTaskName(taskName);
                WorkerModel worker = Mapper.GetWorkerModelById(task.WorkerId);
                ViewBag.Worker = worker;
                List<TaskModel> taskModels = Mapper.GetTaskModelsByTasks();
                return View("GetAllTasks", taskModels.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult GetDoneOrNotReadyTasksAndRelatTerm(string Status, string Term)
        {
            List<TaskModel> taskModels = new List<TaskModel>();
            if (Status == "Done")
            {
                taskModels.AddRange(Mapper.GetDoneTaskModelsByTasks());
            }
            else
            {
                taskModels.AddRange(Mapper.GetNotReadyTaskModelsByTasks());
            }
            if (Term == "Continues")
            {
                for (int i = 0; i < taskModels.Count; i++)
                {
                    if (taskService.isOver(Mapper.GetTaskByTaskModel(taskModels[i])))
                    {
                        taskModels.Remove(taskModels[i]);
                        i--;
                    }
                }
            }
            else
            {
                for (int i = 0; i < taskModels.Count; i++)
                {
                    if (!taskService.isOver(Mapper.GetTaskByTaskModel(taskModels[i])))
                    {
                        taskModels.Remove(taskModels[i]);
                        i--;
                    }
                }
            }
            ViewBag.Tasks = taskModels;
            List<TaskModel> allTasks = Mapper.GetTaskModelsByTasks();
            return View("GetAllTasks", allTasks.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
