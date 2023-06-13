using System.Text.Json;
using VirtualMenu.Abstractions;
using VirtualMenu.Data;
using VirtualMenu.Models;

namespace VirtualMenu.LingaAPI.Services
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
        public async Task<Item> GetMenuItemAsync(string itemId)
        {
            HttpClient client = _clientFactory.CreateClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(ApiEndpoints.BaseAddress + string.Format(ApiEndpoints.GetMenuItem, itemId));
            request.Headers.Add("apikey", _apiSettings.APIKey);

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Item item = JsonSerializer.Deserialize<Item>(responseBody);

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Item>> GetMenuItemsAsync()
        {
            HttpClient client = _clientFactory.CreateClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(ApiEndpoints.BaseAddress + string.Format(ApiEndpoints.GetMenuItems, _apiSettings.StoreId));
            request.Headers.Add("apikey", _apiSettings.APIKey);

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
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
        public async Task<string> GetMenuItemDescriptionAsync(string itemId)
        {
            HttpClient client = _clientFactory.CreateClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(ApiEndpoints.BaseAddress + string.Format(ApiEndpoints.GetMenuItem, itemId));
            request.Headers.Add("apikey", _apiSettings.APIKey);

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Item item = JsonSerializer.Deserialize<Item>(responseBody);

                return item.description;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
