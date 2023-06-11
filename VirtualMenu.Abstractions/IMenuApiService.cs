using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMenu.Models;

namespace VirtualMenu.Abstractions
{
    public interface IMenuApiService
    {
        Task<List<Item>> GetMenuItemsAsync();
        Task<Item> GetMenuItemAsync(string itemId);
        Task<string> GetMenuItemDescriptionAsync(string itemId);
    }
}
