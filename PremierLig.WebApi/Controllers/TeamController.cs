using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.TeamDtos;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _teamService.GetAllTeams();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _teamService.GetTeamById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateTeamDto dto)
        {
            _teamService.CreateTeam(dto);
            return Ok("Takım Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateTeamDto dto)
        {
            _teamService.UpdateTeam(dto);
            return Ok("Takım Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamService.DeleteTeam(id);
            return Ok("Takım Silindi");
        }
    }
}
