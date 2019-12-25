﻿using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    class TaskService : ITaskService
    {
        IUnitRepository unitRepository;

        public TaskService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }
        public void CreateTask(Task task)
        {
            unitRepository.taskRepository.CreateTask(task);
        }
        public void EditTask(Task task)
        {
            unitRepository.taskRepository.EditTask(task);
        }
        public void DeleteTask(int? id)
        {
            unitRepository.taskRepository.DeleteTask(id);
        }
        public List<Task> GetAllTasks()
        {
            return unitRepository.taskRepository.GetAllTasks();
        }
        public List<Task> GetDoneTasks()
        {
            return unitRepository.taskRepository.GetDoneTasks();
        }
        public List<Task> GetNotReadyTasks()
        {
            return unitRepository.taskRepository.GetNotReadyTasks();
        }
    }
}
