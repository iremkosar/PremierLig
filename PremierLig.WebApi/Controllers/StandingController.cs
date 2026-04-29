using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLig.BusinessLayer.Abstract;

namespace PremierLig.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingController : ControllerBase
    {
        private readonly IStandingService _standingService;

        public StandingController(IStandingService standingService)
        {
            _standingService = standingService;
        }

        [HttpGet]
        public IActionResult GetStandings()
        {
            var values = _standingService.GetStandings();
            return Ok(values);
        }
    }
}
