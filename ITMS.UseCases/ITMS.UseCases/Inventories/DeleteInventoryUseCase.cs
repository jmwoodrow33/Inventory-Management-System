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
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(int inventoryId)
        {
            await this.inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
        }
    }
}