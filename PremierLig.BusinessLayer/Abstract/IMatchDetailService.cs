using PremierLig.DtoLayer.MatchDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface IMatchDetailService
    {
        List<ResultMatchDetailDto> GetAllMatchDetails();
        List<ResultMatchDetailDto> GetMatchDetailsByFixtureId(int fixtureId);
        GetByIdMatchDetailDto GetMatchDetailById(int id);
        void CreateMatchDetail(CreateMatchDetailDto dto);
        void UpdateMatchDetail(UpdateMatchDetailDto dto);
        void DeleteMatchDetail(int id);
    }
}
