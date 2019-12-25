using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Services
{
    public class TeamService : ITeamService
    {
        IUnitRepository unitRepository;
        public TeamService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }
        public List<Team> GetAllTeams()
        {
            List<Team> teams = unitRepository.teamRepository.GetAllTeams();
            return teams;
        }
        public List<Worker> GetAllWorkersByTeam(int? id)
        {
            return unitRepository.teamRepository.GetAllWorkersByTeam(id);
        }
    }
}
