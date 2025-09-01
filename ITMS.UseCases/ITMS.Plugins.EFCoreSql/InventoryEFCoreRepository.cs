using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITMS.CoreBusiness;
using ITMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ITMS.Plugins.EFCoreSql
{
    public class InventoryEFCoreRepository : IInventoryRepository
    {
        private readonly IDbContextFactory<ITMSContext> _contextFactory;

        public InventoryEFCoreRepository(IDbContextFactory<ITMSContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            using var db = _contextFactory.CreateDbContext();

            if (string.IsNullOrWhiteSpace(name))
                return await db.Inventories.AsNoTracking()
                         .OrderBy(i => i.InventoryName).ToListAsync();

            var term = name.Trim();
            return await db.Inventories.AsNoTracking()
                .Where(i => EF.Functions.Like(i.InventoryName, $"%{term}%"))
                .OrderBy(i => i.InventoryName)
                .ToListAsync();
        }


        public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Inventories.FindAsync(inventoryId);
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Inventories.Add(inventory);
            await db.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            using var db = _contextFactory.CreateDbContext();
            var inv = await db.Inventories.FindAsync(inventory.InventoryId);
            if (inv is null) return;

            inv.InventoryName = inventory.InventoryName;
            inv.Price = inventory.Price;
            inv.Quantity = inventory.Quantity;

            await db.SaveChangesAsync();
        }

        public async Task DeleteInventoryByIdAsync(int inventoryId)
        {
            using var db = _contextFactory.CreateDbContext();
            var inv = await db.Inventories.FindAsync(inventoryId);
            if (inv is null) return;

            db.Inventories.Remove(inv);
            await db.SaveChangesAsync();
        }
    }
}
