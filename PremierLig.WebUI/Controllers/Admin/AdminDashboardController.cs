using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;

namespace PremierLig.WebUI.Controllers.Admin
{
    public class AdminDashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "https://localhost:7085/api";

        public AdminDashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var fixtureResponse = await client.GetAsync($"{_apiUrl}/Fixture");
            var fixtures = JsonConvert.DeserializeObject<List<ResultFixtureDto>>(
                await fixtureResponse.Content.ReadAsStringAsync()) ?? new();

            var teamResponse = await client.GetAsync($"{_apiUrl}/Team");
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(
                await teamResponse.Content.ReadAsStringAsync()) ?? new();

            ViewBag.TotalMatches = fixtures.Count;
            ViewBag.LiveMatches = fixtures.Count(f => f.Status == 1);
            ViewBag.FinishedMatches = fixtures.Count(f => f.Status == 2);
            ViewBag.UpcomingMatches = fixtures.Count(f => f.Status == 0);
            ViewBag.RecentFixtures = fixtures.Where(f => f.Status == 2)
                .OrderByDescending(f => f.MatchDate).Take(5).ToList();
            ViewBag.Teams = teams;

            return View();
        }
    }
}
