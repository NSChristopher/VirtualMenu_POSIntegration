using System.Text.Json;
using VirtualMenu.Abstractions;
using VirtualMenu.Data;
using VirtualMenu.Models;

namespace API.Services
{
    public class MenuApiService : IMenuApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ApiSettings _apiSettings;

        public MenuApiService(IHttpClientFactory clientFactory, ApiSettings apiSettings)
        {
            _clientFactory = clientFactory;
            _apiSettings = apiSettings;
        }
        public async Task<List<Item>> GetMenuItemsAsync()
        {
            var client = _clientFactory.CreateClient("meta");
            try
            {
                HttpResponseMessage response = await client.GetAsync(string.Format(ApiEndpoints.GetMenuItems, _apiSettings.StoreId));
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
