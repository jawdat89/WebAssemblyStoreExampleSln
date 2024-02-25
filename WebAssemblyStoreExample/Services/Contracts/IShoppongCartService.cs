using WebAssemblyStoreExample.Models.Dtos;

namespace WebAssemblyStoreExample.Services.Contracts
{
    public interface IShoppongCartService
    {
        Task<IEnumerable<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);

    }
}
