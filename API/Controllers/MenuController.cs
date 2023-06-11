using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VirtualMenu.Models;

namespace API.Controllers
{
    [Route("API/[Controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public MenuController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<string> GetMenuItemsAsync()
        {
            HttpClient client = _clientFactory.CreateClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(ApiEndpoints.BaseAddress + string.Format(ApiEndpoints.GetMenuItems, "61f2b8efc1b5f5754ad05512"));
            request.Headers.Add("apikey", "z9uapV1gFBKCaEPBasGa4emXqA5F505a");

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
