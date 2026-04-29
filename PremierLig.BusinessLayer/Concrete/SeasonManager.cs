using AutoMapper;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.SeasonDtos;
using PremierLig.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{  
        public class SeasonManager : ISeasonService
        {
            private readonly PremierLigContext _context;
            private readonly IMapper _mapper;

            public SeasonManager(PremierLigContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public List<ResultSeasonDto> GetAllSeasons()
            {
                var values = _context.Seasons.ToList();
                return _mapper.Map<List<ResultSeasonDto>>(values);
            }

            public void CreateSeason(CreateSeasonDto dto)
            {
                var value = _mapper.Map<Season>(dto);
                _context.Seasons.Add(value);
                _context.SaveChanges();
            }

            public void UpdateSeason(UpdateSeasonDto dto)
            {
                var value = _context.Seasons.Find(dto.SeasonId);
                value.LeagueId = dto.LeagueId;
                value.Name = dto.Name;
                value.StartDate = dto.StartDate;
                value.EndDate = dto.EndDate;
                value.IsCurrent = dto.IsCurrent;
                _context.SaveChanges();
            }

            public void DeleteSeason(int id)
            {
                var value = _context.Seasons.Find(id);
                _context.Seasons.Remove(value);
                _context.SaveChanges();
            }
        }
}
