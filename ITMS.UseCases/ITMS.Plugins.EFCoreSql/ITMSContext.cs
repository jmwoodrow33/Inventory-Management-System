using ITMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace ITMS.Plugins.EFCoreSql
{
    public class ITMSContext : DbContext
    {
        public ITMSContext(DbContextOptions<ITMSContext> options): base(options)
        {
            
        }

        // OPTIONAL: if “provider not configured”, add this fallback:
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer("Server=localhost;Database=ITMS;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        public DbSet<Inventory>? Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().ToTable("Inventories");
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryId = 1, InventoryName = "CPU", Price = 250, Quantity = 10 },
                new Inventory { InventoryId = 2, InventoryName = "Motherboard", Price = 200, Quantity = 5 },
                new Inventory { InventoryId = 3, InventoryName = "Graphics Card", Price = 328, Quantity = 3 },
                new Inventory { InventoryId = 4, InventoryName = "Keyboard", Price = 50, Quantity = 16 }
                );
        }

    }
}
