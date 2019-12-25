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
    public class WorkerModelsController : Controller
    {

        TrackerContext db = new TrackerContext();
        public static int teamId;
        IWorkerService workerService { get; set; }
        ITeamService teamService { get; set; }

        IMapper Mapper { get; set; }

        public WorkerModelsController(IWorkerService workerService, ITeamService teamService, IMapper mapperControl)
        {
            this.workerService = workerService;
            this.teamService = teamService;
            Mapper = mapperControl;
        }

        // GET: WorkerModels
        public ActionResult GetAllTeams()
        {
            if (User.Identity.IsAuthenticated)
            {
                string UserName = User.Identity.Name;
                ViewBag.Teams = Mapper.GetAllTeamModelsByTeams();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult GetMembers(int? id)
        {
            teamId = (int)id;
            if (User.Identity.IsAuthenticated)
            {
                var models = Mapper.GetAllWorkersByTeam(id);
                return View(models.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: WorkerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                WorkerModel model = Mapper.GetWorkerModelById(id);
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


      

        // GET: WorkerModels/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.teamId = teamId;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: WorkerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Position,Phone,Email,Salary,Сongestion,TeamId")] WorkerModel workerModel)
        {
            if (ModelState.IsValid && workerModel.Salary > 1000 && workerModel.Сongestion >= 0.0 && workerModel.Сongestion <= 100.0)
            {
                workerModel.TeamId = teamId;
                var newWorker = Mapper.GetWorkerByWorkerModel(workerModel);
                workerService.AddWorker(newWorker);
                return RedirectToAction("GetMembers", new { Id=teamId });
            }
            return View(workerModel);
        }

        // GET: WorkerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerModel workerModel = Mapper.GetWorkerModelById(id);
            if (workerModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", workerModel.TeamId);
            return View(workerModel);
        }

        // POST: WorkerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Position,Phone,Email,Salary,Сongestion,TeamId")] WorkerModel workerModel)
        {
            if (ModelState.IsValid && workerModel.Salary > 1000 && workerModel.Сongestion >= 0.0 && workerModel.Сongestion <= 100.0)
            {
                var newWorker = Mapper.GetWorkerByWorkerModel(workerModel);
                workerService.EditWorker(newWorker);
                return RedirectToAction("GetMembers", new { Id = teamId });
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", workerModel.TeamId);
            return View(workerModel);
        }

        // GET: WorkerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerModel workerModel = Mapper.GetWorkerModelById(id);
            if (workerModel == null)
            {
                return HttpNotFound();
            }
            return View(workerModel);
        }

        // POST: WorkerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerModel workerModel = Mapper.GetWorkerModelById(id);
            var worker = Mapper.GetWorkerByWorkerModel(workerModel);
            workerService.DeleteWorker(worker.Id);
            return RedirectToAction("GetMembers", new { id=teamId });
        }

        public ActionResult GetWorkerAndHisTasks(string lastName)
        {
            List<WorkerModel> workers = Mapper.GetWorkerModelByLastName(lastName, teamId);
            List<TaskModel> tasks = Mapper.GetTaskModelsByTasks();
            ViewBag.Tasks = tasks;
            return View("GetMembers", workers);
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
