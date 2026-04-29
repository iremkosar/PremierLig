using PremierLig.DtoLayer.StadiumDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface IStadiumService
    {
        List<ResultStadiumDto> GetAllStadiums();
        void CreateStadium(CreateStadiumDto dto);
        void UpdateStadium(UpdateStadiumDto dto);
        void DeleteStadium(int id);
    }
}
