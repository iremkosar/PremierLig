using AutoMapper;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.MatchStatisticDtos;
using PremierLig.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{
    public class MatchStatisticManager:IMatchStatisticService
    {
        private readonly PremierLigContext _context;
        private readonly IMapper _mapper;

        public MatchStatisticManager(PremierLigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ResultMatchStatisticDto> GetAllMatchStatistics()
        {
            var values = _context.MatchStatistics.ToList();
            return _mapper.Map<List<ResultMatchStatisticDto>>(values);
        }

        public ResultMatchStatisticDto GetMatchStatisticByFixtureId(int fixtureId)
        {
            var value = _context.MatchStatistics.FirstOrDefault(x => x.FixtureId == fixtureId);
            return _mapper.Map<ResultMatchStatisticDto>(value);
        }

        public GetByIdMatchStatisticDto GetMatchStatisticById(int id)
        {
            var value = _context.MatchStatistics.Find(id);
            return _mapper.Map<GetByIdMatchStatisticDto>(value);
        }

        public void CreateMatchStatistic(CreateMatchStatisticDto dto)
        {
            var value = _mapper.Map<MatchStatistic>(dto);
            _context.MatchStatistics.Add(value);
            _context.SaveChanges();
        }

        public void UpdateMatchStatistic(UpdateMatchStatisticDto dto)
        {
            var value = _mapper.Map<MatchStatistic>(dto);
            _context.MatchStatistics.Update(value);
            _context.SaveChanges();
        }

        public void DeleteMatchStatistic(int id)
        {
            var value = _context.MatchStatistics.Find(id);
            _context.MatchStatistics.Remove(value);
            _context.SaveChanges();
        }
    }
}
