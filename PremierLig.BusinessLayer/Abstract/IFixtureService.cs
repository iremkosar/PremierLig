using PremierLig.DtoLayer.FixtureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Abstract
{
    public interface IFixtureService
    {
        List<ResultFixtureDto> GetAllFixtures();
        GetByIdFixtureDto GetFixtureById(int id);
        void CreateFixture(CreateFixtureDto dto);
        void UpdateFixture(UpdateFixtureDto dto);
        void DeleteFixture(int id);
    }
}
