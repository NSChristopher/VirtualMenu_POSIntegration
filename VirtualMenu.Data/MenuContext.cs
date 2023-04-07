using Microsoft.EntityFrameworkCore;
using VirtualMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMenu.Data
{
    public class MenuContext : DbContext
    {

        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ServingSizePrice> ServingSizePrices { get; set; }
    }
}
