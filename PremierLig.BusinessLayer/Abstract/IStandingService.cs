using PremierLig.DtoLayer.StandingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface IStandingService
    {
        List<ResultStandingDto> GetStandings();
    }
}
