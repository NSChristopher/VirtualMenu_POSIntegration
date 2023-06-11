using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMenu.Abstractions
{
    public interface IMenuRepository
    {
        Task AddMenuAsync(List<Models.Item> items);
        Task GetMenuAsync();
        Task DeleteMenuAsync();
        Task UpdateMenuAsync();
        Task UpdateItemDescriptionAsync(string itemId, string description);
    }
}
