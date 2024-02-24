using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAssemblyStoreExample.API.Entities;
using WebAssemblyStoreExample.API.Extensions;
using WebAssemblyStoreExample.API.Repositories.Contracts;
using WebAssemblyStoreExample.Models.Dtos;

namespace WebAssemblyStoreExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository _productRepository;

        public ProductController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this._productRepository.GetItems();
                var productCategories = await this._productRepository.GetCategories();

                if (products == null || productCategories == null)
                {
                    return NotFound();
                }

                var productDtos = products.ConvertToDto(productCategories);

                return Ok(productDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
    }
}
