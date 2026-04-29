using AutoMapper;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.LeagueDto;
using PremierLig.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{
    public class LeagueManager : ILeagueService
    {
        private readonly PremierLigContext _context;
        private readonly IMapper _mapper;

        public LeagueManager(PremierLigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ResultLeagueDto> GetAllLeagues()
        {
            var values = _context.Leagues.ToList();
            return _mapper.Map<List<ResultLeagueDto>>(values);
        }

        public void CreateLeague(CreateLeagueDto dto)
        {
            var value = _mapper.Map<League>(dto);
            _context.Leagues.Add(value);
            _context.SaveChanges();
        }

        public void UpdateLeague(UpdateLeagueDto dto)
        {
            var value = _context.Leagues.Find(dto.LeagueId);
            value.Name = dto.Name;
            value.Country = dto.Country;
            _context.SaveChanges();
        }

        public void DeleteLeague(int id)
        {
            var value = _context.Leagues.Find(id);
            _context.Leagues.Remove(value);
            _context.SaveChanges();
        }
    }
}
