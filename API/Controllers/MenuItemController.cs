using Microsoft.AspNetCore.Mvc;
using VirtualMenu.Models;
using System.Text.Json;
using VirtualMenu.Data;

namespace API.Controllers
{
    [Route("API/[Controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private List<Item> items;
        private readonly MenuContext _menuContext;
        private readonly IHttpClientFactory _clientFactory;

        public MenuItemController(IHttpClientFactory clientFactory, MenuContext menuContext)
        {
            _clientFactory = clientFactory;
            _menuContext = menuContext;
        }

        [HttpPost]
        public async Task<ActionResult<string>> LoadMenuItems(string storeId = "63cb0968897d7676ffc0f916")
        {

            var client = _clientFactory.CreateClient("meta");
            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress.ToString() + $"store/{storeId}/menuItems");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<List<Item>>(responseBody);

                using (var menuContext = _menuContext)
                {
                    menuContext.Items.AddRange(items);
                    menuContext.SaveChanges();
                }
                return "Loaded sucessfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<string>> SaveMenuItems()
        {
            Item item = new Item();
            Category cat = new Category();
            cat.id = "catid01";
            cat.name = "pies";
            cat.activeStatus = true;
            ServingSizePrice ssp = new ServingSizePrice();
            ssp.id = "sspid01";
            ssp.name = "each";
            ssp.priceStr = "14.99";
            List<ServingSizePrice> sspList = new List<ServingSizePrice>();
            sspList.Add(ssp);
            item.id = "id01";
            item.category = cat;
            item.name = "pizza";
            item.servingSizePrices = sspList;
            item.description = "";
            item.imageURL = "";
            item.activeStatus = true;
            item.lastAccessed = DateTime.Now;
            try
            {
                using (var menuContext = _menuContext)
                {
                    menuContext.Items.Add(item);
                    menuContext.SaveChanges();
                }
                return "saved sucessfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetMenuItems(string storeId = "63cb0968897d7676ffc0f916")
        {

            var client = _clientFactory.CreateClient("meta");
            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress.ToString() + $"store/{storeId}/menuItems");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                List<Item> items = JsonSerializer.Deserialize<List<Item>>(responseBody);

                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
