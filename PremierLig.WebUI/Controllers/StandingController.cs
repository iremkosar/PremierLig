using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLig.WebUI.Dtos;

namespace PremierLig.WebUI.Controllers
{
    public class StandingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StandingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7085/api/Standing");
            var jsonData = await response.Content.ReadAsStringAsync();
            var standings = JsonConvert.DeserializeObject<List<ResultStandingDto>>(jsonData);

            return View(standings);
        }
    }
}
