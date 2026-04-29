using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.MatchDetailDtos;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchDetailController : ControllerBase
    {
        private readonly IMatchDetailService _matchDetailService;

        public MatchDetailController(IMatchDetailService matchDetailService)
        {
            _matchDetailService = matchDetailService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _matchDetailService.GetAllMatchDetails();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _matchDetailService.GetMatchDetailById(id);
            return Ok(value);
        }

        [HttpGet("ByFixture/{fixtureId}")]
        public IActionResult GetByFixture(int fixtureId)
        {
            var values = _matchDetailService.GetMatchDetailsByFixtureId(fixtureId);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateMatchDetailDto dto)
        {
            _matchDetailService.CreateMatchDetail(dto);
            return Ok("Maç Olayı Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateMatchDetailDto dto)
        {
            _matchDetailService.UpdateMatchDetail(dto);
            return Ok("Maç Olayı Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _matchDetailService.DeleteMatchDetail(id);
            return Ok("Maç Olayı Silindi");
        }
    }
}
