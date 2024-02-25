using Microsoft.AspNetCore.Components;
using WebAssemblyStoreExample.Models.Dtos;
using WebAssemblyStoreExample.Services.Contracts;

namespace WebAssemblyStoreExample.Pages
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public IShoppongCartService ShoppingCartService { get; set; }

        public IEnumerable<CartItemDto> ShoppingCartItems { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
