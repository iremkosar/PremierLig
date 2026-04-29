using PremierLig.DtoLayer.LeagueDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface ILeagueService
    {
        List<ResultLeagueDto> GetAllLeagues();
        void CreateLeague(CreateLeagueDto dto);
        void UpdateLeague(UpdateLeagueDto dto);
        void DeleteLeague(int id);
    }
}
