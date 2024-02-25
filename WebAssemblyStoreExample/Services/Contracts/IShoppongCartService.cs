using WebAssemblyStoreExample.Models.Dtos;

namespace WebAssemblyStoreExample.Services.Contracts
{
    public interface IShoppongCartService
    {
        Task<List<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItemDto> DeleteItem(int id);
    }
}
