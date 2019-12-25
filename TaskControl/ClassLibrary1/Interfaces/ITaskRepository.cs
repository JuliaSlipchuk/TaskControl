﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ITaskRepository
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