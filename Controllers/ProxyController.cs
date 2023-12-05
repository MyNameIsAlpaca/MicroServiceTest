using Microsoft.AspNetCore.Mvc;

namespace ProxyHttp.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private HttpClient _httpClient;
        
        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();

        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            return await ProxyToService("https://localhost:44314/Authors");
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            return await ProxyToService("https://localhost:44322/Books");
        }

        private async Task<ContentResult> ProxyToService(string url) => Content(await _httpClient.GetStringAsync(url));
    }
}
