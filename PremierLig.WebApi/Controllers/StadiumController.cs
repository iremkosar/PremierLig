using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.StadiumDto;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_stadiumService.GetAllStadiums());
        }

        [HttpPost]
        public IActionResult Create(CreateStadiumDto dto)
        {
            _stadiumService.CreateStadium(dto);
            return Ok("Stadyum Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateStadiumDto dto)
        {
            _stadiumService.UpdateStadium(dto);
            return Ok("Stadyum Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _stadiumService.DeleteStadium(id);
            return Ok("Stadyum Silindi");
        }
    }
}
