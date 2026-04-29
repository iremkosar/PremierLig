using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;
using System.Text;

namespace PremierLig.WebUI.Controllers.Admin
{
    public class AdminMatchEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "https://localhost:7085/api";

        public AdminMatchEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var fixtureResponse = await client.GetAsync($"{_apiUrl}/Fixture/{id}");
            var fixtureBody = await fixtureResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Fixture: {fixtureBody}");
            var fixture = JsonConvert.DeserializeObject<ResultFixtureDto>(fixtureBody);

            var detailResponse = await client.GetAsync($"{_apiUrl}/MatchDetail/ByFixture/{id}");
            var detailBody = await detailResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Details: {detailBody}");

            List<ResultMatchDetailDto> details = new();
            if (detailResponse.IsSuccessStatusCode)
                details = JsonConvert.DeserializeObject<List<ResultMatchDetailDto>>(detailBody) ?? new();

            var teamResponse = await client.GetAsync($"{_apiUrl}/Team");
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(
                await teamResponse.Content.ReadAsStringAsync());

            ViewBag.Fixture = fixture;
            ViewBag.Details = details;
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMatchDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync($"{_apiUrl}/MatchDetail", content);
            return RedirectToAction("Index", new { id = dto.FixtureId });
        }

        public async Task<IActionResult> Delete(int id, int fixtureId)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"{_apiUrl}/MatchDetail/{id}");
            return RedirectToAction("Index", new { id = fixtureId });
        }
    }
}
