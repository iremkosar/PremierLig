using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;
using PremierLig.WebUI.Models;
using System.Diagnostics;

namespace PremierLig.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
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

            ViewBag.Teams = teams;
            return View(fixtures);
        }
    }
}
