using AutoMapper;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.StadiumDto;
using PremierLig.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{
    public class StadiumManager : IStadiumService
    {
        private readonly PremierLigContext _context;
        private readonly IMapper _mapper;

        public StadiumManager(PremierLigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ResultStadiumDto> GetAllStadiums()
        {
            var values = _context.Stadiums.ToList();
            return _mapper.Map<List<ResultStadiumDto>>(values);
        }

        public void CreateStadium(CreateStadiumDto dto)
        {
            var value = _mapper.Map<Stadium>(dto);
            _context.Stadiums.Add(value);
            _context.SaveChanges();
        }

        public void UpdateStadium(UpdateStadiumDto dto)
        {
            var value = _context.Stadiums.Find(dto.StadiumId);
            value.Name = dto.Name;
            value.City = dto.City;
            value.Capacity = dto.Capacity;
            _context.SaveChanges();
        }

        public void DeleteStadium(int id)
        {
            var value = _context.Stadiums.Find(id);
            _context.Stadiums.Remove(value);
            _context.SaveChanges();
        }
    }
}
