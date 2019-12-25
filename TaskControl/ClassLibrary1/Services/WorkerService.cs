using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class WorkerService : IWorkerService
    {
        IUnitRepository unitRepository;

        public WorkerService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }
        public void AddWorker(Worker worker)
        {
            unitRepository.workerRepository.AddWorker(worker);
        }
        public void EditWorker(Worker worker)
        {
            unitRepository.workerRepository.EditWorker(worker);
        }
        public void DeleteWorker(int? id)
        {
            unitRepository.workerRepository.DeleteWorker(id);
        }
        public Worker GetWorkerById(int? id)
        {
            return unitRepository.workerRepository.GetWorkerById(id);
        }
        public List<Worker> GetAllWorkers()
        {
            return unitRepository.workerRepository.GetAllWorkers();
        }
        public List<Worker> GetWorkerByLastName(string lastName, int teamId)
        {
            return unitRepository.workerRepository.GetWorkerByLastName(lastName, teamId);
        }
    }
}
