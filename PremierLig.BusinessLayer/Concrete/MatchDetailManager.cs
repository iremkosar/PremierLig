using AutoMapper;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.MatchDetailDtos;
using PremierLig.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{
    public class MatchDetailManager:IMatchDetailService
    {
        private readonly PremierLigContext _context;
        private readonly IMapper _mapper;

        public MatchDetailManager(PremierLigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ResultMatchDetailDto> GetAllMatchDetails()
        {
            var values = _context.MatchDetails.ToList();
            return _mapper.Map<List<ResultMatchDetailDto>>(values);
        }

        public List<ResultMatchDetailDto> GetMatchDetailsByFixtureId(int fixtureId)
        {
            var values = _context.MatchDetails.Where(m => m.FixtureId == fixtureId).ToList();
            return _mapper.Map<List<ResultMatchDetailDto>>(values);
        }

        public GetByIdMatchDetailDto GetMatchDetailById(int id)
        {
            var value = _context.MatchDetails.Find(id);
            return _mapper.Map<GetByIdMatchDetailDto>(value);
        }

        public void CreateMatchDetail(CreateMatchDetailDto dto)
        {
            var value = _mapper.Map<MatchDetail>(dto);
            _context.MatchDetails.Add(value);
            _context.SaveChanges();
        }

        public void UpdateMatchDetail(UpdateMatchDetailDto dto)
        {
            var value = _context.MatchDetails.Find(dto.MatchDetailId);
            value.FixtureId = dto.FixtureId;
            value.Minute = dto.Minute;
            value.ActionType = dto.ActionType;
            value.Description = dto.Description;
            value.TeamId = dto.TeamId;
            _context.SaveChanges();
        }

        public void DeleteMatchDetail(int id)
        {
            var value = _context.MatchDetails.Find(id);
            _context.MatchDetails.Remove(value);
            _context.SaveChanges();
        }
    }
}
