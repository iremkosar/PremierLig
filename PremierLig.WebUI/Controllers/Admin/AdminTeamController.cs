using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;
using System.Text;

namespace PremierLig.WebUI.Controllers.Admin
{
    public class AdminTeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "https://localhost:7085/api";

        public AdminTeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiUrl}/Team");
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(
                await response.Content.ReadAsStringAsync());
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync($"{_apiUrl}/Team", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiUrl}/Team/{id}");
            var team = JsonConvert.DeserializeObject<UpdateTeamDto>(
                await response.Content.ReadAsStringAsync());
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTeamDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync($"{_apiUrl}/Team", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"{_apiUrl}/Team/{id}");
            return RedirectToAction("Index");
        }
    }
}
