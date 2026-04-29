using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;
using System.Text;

namespace PremierLig.WebUI.Controllers.Admin
{
    public class AdminSeasonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "https://localhost:7085/api";

        public AdminSeasonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiUrl}/Season");
            var seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(
                await response.Content.ReadAsStringAsync());
            return View(seasons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSeasonDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync($"{_apiUrl}/Season", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiUrl}/Season");
            var seasons = JsonConvert.DeserializeObject<List<UpdateSeasonDto>>(
                await response.Content.ReadAsStringAsync());
            var season = seasons?.FirstOrDefault(s => s.SeasonId == id);
            return View(season);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSeasonDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync($"{_apiUrl}/Season", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"{_apiUrl}/Season/{id}");
            return RedirectToAction("Index");
        }
    }
}
