using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.LeagueDto;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_leagueService.GetAllLeagues());
        }

        [HttpPost]
        public IActionResult Create(CreateLeagueDto dto)
        {
            _leagueService.CreateLeague(dto);
            return Ok("Lig Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateLeagueDto dto)
        {
            _leagueService.UpdateLeague(dto);
            return Ok("Lig Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _leagueService.DeleteLeague(id);
            return Ok("Lig Silindi");
        }
    }
}
