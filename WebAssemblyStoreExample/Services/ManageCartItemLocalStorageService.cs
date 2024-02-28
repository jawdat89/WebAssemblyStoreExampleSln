using Blazored.LocalStorage;
using WebAssemblyStoreExample.Models.Dtos;
using WebAssemblyStoreExample.Services.Contracts;

namespace WebAssemblyStoreExample.Services
{
    public class ManageCartItemLocalStorageService : IManageCartItemsLocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IShoppingCartService _shoppingCartService;

        private const string key = "CartItemCollection";

        public ManageCartItemLocalStorageService(ILocalStorageService localStorageService, IShoppingCartService shoppingCartService)
        {
            _localStorageService = localStorageService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<List<CartItemDto>> GetCollection()
        {
            return await _localStorageService.GetItemAsync<List<CartItemDto>>(key) ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            await _localStorageService.SetItemAsync(key, cartItemDtos);
        }

        private async Task<List<CartItemDto>> AddCollection()
        {
            var shoppingCartCollection = await _shoppingCartService.GetItems(HardCoded.UserId);

            if (shoppingCartCollection != null)
            {
                await _localStorageService.SetItemAsync(key, shoppingCartCollection);
            }

            return shoppingCartCollection;
        }
    }
}
