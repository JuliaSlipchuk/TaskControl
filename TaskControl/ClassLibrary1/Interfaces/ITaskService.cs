using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        void CreateTask(Task task);
        void EditTask(Task task);
        void DeleteTask(int? id);
        Task GetTaskById(int? id);
        List<Task> GetAllTasks();
        List<Task> GetDoneTasks();
        List<Task> GetNotReadyTasks();
        Task GetTaskByTaskName(string taskName);
        bool isOver(Task task);
    }
}
