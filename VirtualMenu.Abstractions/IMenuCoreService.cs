using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMenu.Models;

namespace VirtualMenu.Abstractions
{
    public interface IMenuCoreService
    {
        Task<List<Item>> GetMenuItemsCoreAsync();
        Task SaveMenuItemsCoreAsync();
        Task UpdateMenuItemsCoreAsync();
        Task DeleteMenuItemsCoreAsync();
        Task UpdateMenuItemDescriptionsAsync();
    }
}
