using BusinessLogic.EF;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogic.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        TrackerContext db = new TrackerContext();
        public void AddWorker(Worker worker)
        {
            if (worker != null)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
            }
        }
        public void EditWorker(Worker worker)
        {
            if (worker != null)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteWorker(int? id)
        {
            if (id != null)
            {
                Worker worker = GetWorkerById(id);
                if (worker != null)
                {
                    List<Task> tasks = db.Tasks.Where(t => t.WorkerId == id).ToList();
                    db.Tasks.RemoveRange(tasks);
                    db.Workers.Remove(worker);
                    db.SaveChanges();
                }
            }
        }
        public Worker GetWorkerById(int? id)
        {
            Worker worker = db.Workers.Where(w => w.Id == id).ToList()[0];
            return worker;
        }
        public List<Worker> GetAllWorkers()
        {
            return db.Workers.ToList();
        }
        public List<Worker> GetWorkerByLastName(string lastName, int teamId)
        {
            List<Worker> workers = db.Workers.Where(w => w.LastName.Contains(lastName) && w.TeamId == teamId).ToList();
            return workers;
        }
    }
}
