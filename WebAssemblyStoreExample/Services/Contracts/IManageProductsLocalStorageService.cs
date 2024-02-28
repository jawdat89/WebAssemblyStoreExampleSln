using WebAssemblyStoreExample.Models.Dtos;

namespace WebAssemblyStoreExample.Services.Contracts
{
    public interface IManageProductsLocalStorageService
    {
        Task<IEnumerable<ProductDto>> GetCollection();
        Task RemoveCollection();
    }
}
