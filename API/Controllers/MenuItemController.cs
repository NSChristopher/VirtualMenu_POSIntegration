using Microsoft.AspNetCore.Mvc;
using Models;
using System.Text.Json;

namespace API.Controllers
{
    [Route("API/[Controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {

        private readonly IHttpClientFactory _clientFactory;

        public MenuItemController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetMenuItems()
        {

            var client = _clientFactory.CreateClient("meta");
            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress.ToString() + $"store/63cb0968897d7676ffc0f916/menuItems");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                List<Item> item = JsonSerializer.Deserialize<List<Item>>(responseBody);

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
