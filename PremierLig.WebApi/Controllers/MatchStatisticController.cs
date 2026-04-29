using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.DataAccessLayer.Context;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticController : ControllerBase
    {
        private readonly PremierLigContext _context;

        public MatchStatisticController(PremierLigContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.MatchStatistics.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.MatchStatistics.Find(id);
            return Ok(value);
        }

        [HttpGet("ByFixture/{fixtureId}")]
        public IActionResult GetByFixture(int fixtureId)
        {
            var value = _context.MatchStatistics
                .FirstOrDefault(x => x.FixtureId == fixtureId);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(MatchStatistic matchStatistic)
        {
            _context.MatchStatistics.Add(matchStatistic);
            _context.SaveChanges();
            return Ok("İstatistik Eklendi");
        }

        [HttpPut]
        public IActionResult Update(MatchStatistic matchStatistic)
        {
            _context.MatchStatistics.Update(matchStatistic);
            _context.SaveChanges();
            return Ok("İstatistik Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.MatchStatistics.Find(id);
            _context.MatchStatistics.Remove(value);
            _context.SaveChanges();
            return Ok("İstatistik Silindi");
        }

    }
}
