using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.SeasonDtos;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;

        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_seasonService.GetAllSeasons());
        }

        [HttpPost]
        public IActionResult Create(CreateSeasonDto dto)
        {
            _seasonService.CreateSeason(dto);
            return Ok("Sezon Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateSeasonDto dto)
        {
            _seasonService.UpdateSeason(dto);
            return Ok("Sezon Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _seasonService.DeleteSeason(id);
            return Ok("Sezon Silindi");
        }
    }
}
