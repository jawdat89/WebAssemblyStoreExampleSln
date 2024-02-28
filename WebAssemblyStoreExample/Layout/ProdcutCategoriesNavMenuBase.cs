using Microsoft.AspNetCore.Components;
using WebAssemblyStoreExample.Models.Dtos;
using WebAssemblyStoreExample.Services.Contracts;

namespace WebAssemblyStoreExample.Layout
{
    public class ProdcutCategoriesNavMenuBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductCategoryDto> ProductCategoryDtos { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ProductCategoryDtos = await ProductService.GetProductCategories();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
