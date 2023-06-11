using System.Threading.Tasks.Dataflow;
using VirtualMenu.Abstractions;
using VirtualMenu.Models;

namespace VirtualMenu.Core.Services
{
    public class MenuCoreService : IMenuCoreService
    {
        private readonly IMenuApiService _apiService;
        private readonly IMenuRepository _menuRepository;
        public MenuCoreService(IMenuApiService apiService, IMenuRepository menuRepository)
        {
            _apiService = apiService;
            _menuRepository = menuRepository;
        }

        public Task DeleteMenuItemsCoreAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Item>> GetMenuItemsCoreAsync()
        {
            return await _apiService.GetMenuItemsAsync();
        }

        public async Task SaveMenuItemsCoreAsync()
        {
            List<Item> items = await _apiService.GetMenuItemsAsync();
            _menuRepository.AddMenuAsync(items);
        }

        public Task UpdateMenuItemDescriptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMenuItemsCoreAsync()
        {
            throw new NotImplementedException();
        }
    }
}