using PremierLig.DtoLayer.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface ITeamService
    {
        List<ResultTeamDto> GetAllTeams();
        GetByIdTeamDto GetTeamById(int id);
        void CreateTeam(CreateTeamDto dto);
        void UpdateTeam(UpdateTeamDto dto);
        void DeleteTeam(int id);
    }
}
