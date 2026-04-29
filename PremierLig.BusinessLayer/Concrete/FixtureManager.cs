using AutoMapper;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.FixtureDtos;
using PremierLig.EntityLayer.Entities;
using PremierLig.DtoLayer.MatchDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{
    public class FixtureManager:IFixtureService
    {
        private readonly PremierLigContext _context;
        private readonly IMapper _mapper;

        public FixtureManager(PremierLigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ResultFixtureDto> GetAllFixtures()
        {
            var fixtures = _context.Fixtures.ToList();
            return _mapper.Map<List<ResultFixtureDto>>(fixtures);
        }

        public GetByIdFixtureDto GetFixtureById(int id)
        {
            var fixture = _context.Fixtures.Find(id);

            if (fixture == null)
                return null;

            var matchDetails = _context.MatchDetails
                .Where(m => m.FixtureId == id)
                .ToList();

            return new GetByIdFixtureDto
            {
                FixtureId = fixture.FixtureId,
                HomeTeamId = fixture.HomeTeamId,
                AwayTeamId = fixture.AwayTeamId,
                MatchDate = fixture.MatchDate,
                HomeScore = fixture.HomeScore,
                AwayScore = fixture.AwayScore,
                Status = fixture.Status,
                WeekNumber = fixture.WeekNumber,
                SeasonId = fixture.SeasonId,
                StadiumId = fixture.StadiumId,
                Referee = fixture.Referee,
                Attendance = fixture.Attendance,
                MatchDetails = matchDetails.Select(d => new ResultMatchDetailDto
                {
                    MatchDetailId = d.MatchDetailId,
                    FixtureId = d.FixtureId,
                    TeamId = d.TeamId,
                    Minute = d.Minute,
                    ActionType = d.ActionType,
                    Description = d.Description
                }).ToList()
            };
        }

        public void CreateFixture(CreateFixtureDto dto)
        {
            var fixture = _mapper.Map<Fixture>(dto);
            _context.Fixtures.Add(fixture);
            _context.SaveChanges();
        }

        public void UpdateFixture(UpdateFixtureDto dto)
        {
            var fixture = _context.Fixtures.Find(dto.FixtureId);
            if (fixture == null) return;

            fixture.HomeScore = dto.HomeScore;
            fixture.AwayScore = dto.AwayScore;
            fixture.Status = dto.Status;
            fixture.StadiumId = dto.StadiumId;
            fixture.SeasonId = dto.SeasonId;
            fixture.Referee = dto.Referee;
            fixture.Attendance = dto.Attendance;
            fixture.MatchDate = dto.MatchDate;
            fixture.WeekNumber = dto.WeekNumber;

            _context.SaveChanges();
        }

        public void DeleteFixture(int id)
        {
            var fixture = _context.Fixtures.Find(id);
            _context.Fixtures.Remove(fixture);
            _context.SaveChanges();
        }
    }
}
