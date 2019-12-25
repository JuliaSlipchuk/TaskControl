using BusinessLogic.EF;
using BusinessLogic.Entities;
using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        TrackerContext db = new TrackerContext();
        public List<Team> GetAllTeams()
        {
            return db.Teams.ToList();
        }
        public List<Worker> GetAllWorkersByTeam(int? id)
        {
            return db.Workers.Where(w => w.TeamId == id).ToList();
        }
    }
}
