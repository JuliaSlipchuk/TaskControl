using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    interface ITaskService
    {
        void CreateTask(Task task);
        void EditTask(Task task);
        void DeleteTask(int? id);
        List<Task> GetAllTasks();
        List<Task> GetDoneTasks();
        List<Task> GetNotReadyTasks();
    }
}
