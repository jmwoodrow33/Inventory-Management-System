using ITMS.CoreBusiness;

namespace ITMS.UseCases.Inventories.Interfaces
{
    public interface IDeleteInventoryUseCase
    {
        Task ExecuteAsync(int inventoryId);
    }
}