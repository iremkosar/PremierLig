using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;

namespace PremierLig.WebUI.Controllers
{
    public class MatchDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var fixtureResponse = await client.GetAsync($"https://localhost:7085/api/Fixture/{id}");
                var fixtureJson = await fixtureResponse.Content.ReadAsStringAsync();
                var fixture = JsonConvert.DeserializeObject<PremierLig.WebUI.Dtos.ResultFixtureDto>(fixtureJson);

                var detailResponse = await client.GetAsync($"https://localhost:7085/api/MatchDetail/ByFixture/{id}");
                var detailJson = await detailResponse.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<List<PremierLig.WebUI.Dtos.ResultMatchDetailDto>>(detailJson);

                var statResponse = await client.GetAsync($"https://localhost:7085/api/MatchStatistic/ByFixture/{id}");
                var statJson = await statResponse.Content.ReadAsStringAsync();
                var stat = JsonConvert.DeserializeObject<PremierLig.WebUI.Dtos.ResultMatchStatisticDto>(statJson);

                var teamResponse = await client.GetAsync("https://localhost:7085/api/Team");
                var teamJson = await teamResponse.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<PremierLig.WebUI.Dtos.ResultTeamDto>>(teamJson);

                var stadiumResponse = await client.GetAsync("https://localhost:7085/api/Stadium");
                var stadiumJson = await stadiumResponse.Content.ReadAsStringAsync();
                var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(stadiumJson);
              
                ViewBag.Stadiums = stadiums;
                ViewBag.Fixture = fixture;
                ViewBag.Details = details;
                ViewBag.Stat = stat;
                ViewBag.Teams = teams;

                return View();
            }
            catch (Exception ex)
            {
                return Content("Hata: " + ex.Message);
            }
        }
    }
}
