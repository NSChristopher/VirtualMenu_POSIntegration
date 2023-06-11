using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMenu.Abstractions;
using VirtualMenu.Models;

namespace VirtualMenu.Data.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MenuContext _context;
        public MenuRepository(MenuContext context)
        {
            _context = context;
        }

        public async Task AddMenuAsync(List<Item> items)
        {
            try
            {
                // seperate this into two method and store them in VirtualMenu.API. Here we should only been to addrange and savechanges.

                // Make sure all categories are referencing the same object so EF doesn't try to add them all again
                foreach (Item item in items)
                {
                    var existingCategory = _context.Categories.FirstOrDefault(c => c.id == item.category.id);
                    if (existingCategory != null)
                    {
                        item.category = existingCategory;
                    }
                    else
                    {
                        // If the category does not exist in the database, add it
                        _context.Categories.Add(item.category);
                        _context.SaveChanges(); // save the new category so it gets an id
                    }
                }

                // Add the items to the database
                _context.Items.AddRange(items
                    .Select(i => new Item
                    {
                        itemId = i.itemId,
                        activeStatus = i.activeStatus,
                        name = i.name,
                        category = i.category,
                        servingSizePrices = i.servingSizePrices
                            .Select(i => new ServingSizePrice
                            {
                                // servingSizeId is null so EF will generate a new unique id. the original id's are refrencing multiple unique objects.
                                servingSizeId = null,
                                name = i.name,
                                priceStr = i.priceStr
                            }).ToList(),
                        imageURL = i.imageURL,
                        // custome field. datetime is set to now.
                        lastAccessed = DateTime.Now
                    }));

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Task DeleteMenuAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetMenuAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemDescriptionAsync(string itemId, string description)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMenuAsync()
        {
            throw new NotImplementedException();
        }
    }
}
