using AutoMapper;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.TeamDtos;
using PremierLig.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{
    public class TeamManager:ITeamService
    {
        private readonly PremierLigContext _context;
        private readonly IMapper _mapper;

        public TeamManager(PremierLigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ResultTeamDto> GetAllTeams()
        {
            var teams = _context.Teams.ToList();
            return _mapper.Map<List<ResultTeamDto>>(teams);
        }

        public GetByIdTeamDto GetTeamById(int id)
        {
            var team = _context.Teams.Find(id);
            return _mapper.Map<GetByIdTeamDto>(team);
        }

        public void CreateTeam(CreateTeamDto dto)
        {
            var team = _mapper.Map<Team>(dto);
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void UpdateTeam(UpdateTeamDto dto)
        {
            var team = _context.Teams.Find(dto.TeamId);
            if (team == null) return;

            team.TeamName = dto.TeamName;
            team.ShortName = dto.ShortName;
            team.LogoUrl = dto.LogoUrl;
            team.StadiumName = dto.StadiumName;
            team.City = dto.City;

            _context.SaveChanges();
        }

        public void DeleteTeam(int id)
        {
            var team = _context.Teams.Find(id);
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
    }
}
