using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.FixtureDtos;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IFixtureService _fixtureService;

        public FixtureController(IFixtureService fixtureService)
        {
            _fixtureService = fixtureService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _fixtureService.GetAllFixtures();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _fixtureService.GetFixtureById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateFixtureDto dto)
        {
            _fixtureService.CreateFixture(dto);
            return Ok("Maç Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFixtureDto dto)
        {
            _fixtureService.UpdateFixture(dto);
            return Ok("Maç Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _fixtureService.DeleteFixture(id);
            return Ok("Maç Silindi");
        }


    }
}
