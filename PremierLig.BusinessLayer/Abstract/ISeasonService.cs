using PremierLig.DtoLayer.SeasonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface ISeasonService
    {
        List<ResultSeasonDto> GetAllSeasons();
        void CreateSeason(CreateSeasonDto dto);
        void UpdateSeason(UpdateSeasonDto dto);
        void DeleteSeason(int id);
    }
}
