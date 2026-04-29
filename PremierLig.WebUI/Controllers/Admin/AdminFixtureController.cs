using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;
using System.Text;

namespace PremierLig.WebUI.Controllers
{
    public class AdminFixtureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "https://localhost:7085/api";

        public AdminFixtureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var fixtureResponse = await client.GetAsync($"{_apiUrl}/Fixture");
            var fixtures = JsonConvert.DeserializeObject<List<ResultFixtureDto>>(
                await fixtureResponse.Content.ReadAsStringAsync());

            var teamResponse = await client.GetAsync($"{_apiUrl}/Team");
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(
                await teamResponse.Content.ReadAsStringAsync());

            var stadiumResponse = await client.GetAsync($"{_apiUrl}/Stadium");
            var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(
                await stadiumResponse.Content.ReadAsStringAsync());

            ViewBag.Teams = teams;
            ViewBag.Stadiums = stadiums;
            return View(fixtures);
        }

        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();

            var teamResponse = await client.GetAsync($"{_apiUrl}/Team");
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(
                await teamResponse.Content.ReadAsStringAsync());

            var stadiumResponse = await client.GetAsync($"{_apiUrl}/Stadium");
            var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(
                await stadiumResponse.Content.ReadAsStringAsync());

            ViewBag.Teams = teams;
            ViewBag.Stadiums = stadiums;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFixtureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_apiUrl}/Fixture", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            // API'den dönen hata mesajını oku
            var errorBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API Hatası: {response.StatusCode} - {errorBody}");
            ModelState.AddModelError("", $"API Hatası: {response.StatusCode} - {errorBody}");

            var teamResponse = await client.GetAsync($"{_apiUrl}/Team");
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(
                await teamResponse.Content.ReadAsStringAsync());
            var stadiumResponse = await client.GetAsync($"{_apiUrl}/Stadium");
            var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(
                await stadiumResponse.Content.ReadAsStringAsync());

            ViewBag.Teams = teams;
            ViewBag.Stadiums = stadiums;
            return View(dto);
        }

        public async Task<IActionResult> UpdateScore(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var fixtureResponse = await client.GetAsync($"{_apiUrl}/Fixture/{id}");
            var fixture = JsonConvert.DeserializeObject<ResultFixtureDto>(
                await fixtureResponse.Content.ReadAsStringAsync());

            var teamResponse = await client.GetAsync($"{_apiUrl}/Team");
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(
                await teamResponse.Content.ReadAsStringAsync());

            var stadiumResponse = await client.GetAsync($"{_apiUrl}/Stadium");
            var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(
                await stadiumResponse.Content.ReadAsStringAsync());

            ViewBag.Teams = teams;
            ViewBag.Stadiums = stadiums;
            return View(fixture);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateScore(UpdateFixtureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{_apiUrl}/Fixture", content);

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Update Status: {response.StatusCode} - {responseBody}");
            Console.WriteLine($"Gönderilen DTO: {json}");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"{_apiUrl}/Fixture/{id}");
            return RedirectToAction("Index");
        }
    }
}
