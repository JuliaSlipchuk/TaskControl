using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface ITeamService
    {
        List<Team> GetAllTeams();
        List<Worker> GetAllWorkersByTeam(int? id);
    }
}
