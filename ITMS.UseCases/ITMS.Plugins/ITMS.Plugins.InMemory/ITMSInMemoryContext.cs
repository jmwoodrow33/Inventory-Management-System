using ITMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMS.Plugins.InMemory
{
    public class ITMSInMemoryContext : DbContext
    {
        public ITMSInMemoryContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet <Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryId = 3, InventoryName = "RAM", Price = 150, Quantity = 30},
                new Inventory { InventoryId = 4, InventoryName = "Graphics Card", Price = 250, Quantity = 15 },
                new Inventory { InventoryId = 5, InventoryName = "Keyboard", Price = 75, Quantity = 7 }
                );
        }
    }
}
