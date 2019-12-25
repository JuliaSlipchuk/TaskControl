﻿using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IWorkerRepository
    {
        void AddWorker(Worker worker);
        void EditWorker(Worker worker);
        void DeleteWorker(int? id);
        Worker GetWorkerById(int? id);
        List<Worker> GetAllWorkers();
        List<Worker> GetWorkerByLastName(string lastName, int teamId);
    }
}