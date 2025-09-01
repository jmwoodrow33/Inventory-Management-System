using ITMS.CoreBusiness;
using ITMS.UseCases.Inventories.Interfaces;
using ITMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMS.UseCases.Inventories
{
    public sealed class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
    {
        private readonly IInventoryRepository _repo; // inject the interface

        public ViewInventoryByIdUseCase(IInventoryRepository repo) => _repo = repo;

        public Task<Inventory?> ExecuteAsync(int inventoryId)
            => _repo.GetInventoryByIdAsync(inventoryId); // no casting, returns single item
    }
}
