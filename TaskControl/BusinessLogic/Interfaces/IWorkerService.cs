using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    interface IWorkerService
    {
        void AddWorker(Worker worker);
        void EditWorker(Worker worker);
        void DeleteWorker(int? id);
        Worker GetWorkerById(int? id);
        List<Worker> GetAllWorkers();
    }
}
