using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;

namespace PremierLig.WebUI.Controllers
{
    public class FixtureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FixtureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var fixtureResponse = await client.GetAsync("https://localhost:7085/api/Fixture");
            var fixtureJson = await fixtureResponse.Content.ReadAsStringAsync();
            var fixtures = JsonConvert.DeserializeObject<List<ResultFixtureDto>>(fixtureJson);

            var teamResponse = await client.GetAsync("https://localhost:7085/api/Team");
            var teamJson = await teamResponse.Content.ReadAsStringAsync();
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJson);

            var stadiumResponse = await client.GetAsync("https://localhost:7085/api/Stadium");
            var stadiumJson = await stadiumResponse.Content.ReadAsStringAsync();
            var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(stadiumJson);

            ViewBag.Teams = teams;
            ViewBag.Stadiums = stadiums;
            return View(fixtures);
        }
    }
}
