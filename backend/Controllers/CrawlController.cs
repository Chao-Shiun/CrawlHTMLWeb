using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrawlHtmlWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrawlController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CrawlController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetHtml([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url) || !Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                return BadRequest("Invalid URL");
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var html = await response.Content.ReadAsStringAsync();
                return Content(html, "text/html");
            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, $"Error fetching URL: {e.Message}");
            }
        }
    }
}
