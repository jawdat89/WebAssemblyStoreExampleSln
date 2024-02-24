using Microsoft.AspNetCore.Components;
using WebAssemblyStoreExample.Models.Dtos;

namespace WebAssemblyStoreExample.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
