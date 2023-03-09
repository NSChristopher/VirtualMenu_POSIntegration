using ClassLibrary;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Item>> GetCustomer(string storeId = "5c5981496bcf7500013afeb0")
        {

            var client = _clientFactory.CreateClient("meta");

            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress.ToString() + $"menuItem/615348c7c67b33d994771e8a");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
