using PremierLig.DtoLayer.MatchStatisticDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface IMatchStatisticService
    {
        List<ResultMatchStatisticDto> GetAllMatchStatistics();
        ResultMatchStatisticDto GetMatchStatisticByFixtureId(int fixtureId);
        GetByIdMatchStatisticDto GetMatchStatisticById(int id);
        void CreateMatchStatistic(CreateMatchStatisticDto dto);
        void UpdateMatchStatistic(UpdateMatchStatisticDto dto);
        void DeleteMatchStatistic(int id);
    }
}
