using NLayerApp.DAL.Entities;
using System;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Team> Teams { get; }
        IRepository<Project> Projects { get; }
        IRepository<Worker> Workers { get; }
        IRepository<Task> Tasks { get; }
        void Save();
    }
}