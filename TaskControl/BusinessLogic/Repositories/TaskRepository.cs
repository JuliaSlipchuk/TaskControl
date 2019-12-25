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
    class TaskRepository : ITaskRepository
    {
        TrackerContext db;
        public void CreateTask(Task task)
        {
            if (task != null)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }
        public void EditTask(Task task)
        {
            if (task != null)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteTask(int? id)
        {
            if (id != null)
            {
                Task task = GetTaskById(id);
                if (task != null)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                }
            }
        }
        public Task GetTaskById(int? id)
        {
            return db.Tasks.Where(t => t.Id == id).ToList()[0];
        }
        public List<Task> GetAllTasks()
        {
            return db.Tasks.ToList();
        }
        public List<Task> GetDoneTasks()
        {
            return db.Tasks.Where(t => t.Status == "Done").ToList();
        }
        public List<Task> GetNotReadyTasks()
        {
            return db.Tasks.Where(t => t.Status == "Not ready").ToList();
        }
    }
}
