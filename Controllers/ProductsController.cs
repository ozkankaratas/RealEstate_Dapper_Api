using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsyn();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İlan Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok("İlan Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productRepository.UpdateProduct(updateProductDto);
            return Ok("İlan Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var values = await _productRepository.GetProductById(id);
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpPut("ChangeDealOfTheDayStatusToFalse/{id}")]
        public async Task<IActionResult> ChangeDealOfTheDayStatusToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
        }

        [HttpPut("ChangeDealOfTheDayStatusToTrue/{id}")]
        public async Task<IActionResult> ChangeDealOfTheDayStatusToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi");
        }

        [HttpPut("ChangeStatusToFalse/{id}")]
        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            _productRepository.ProductStatusChangeToFalse(id);
            return Ok("İlan Durumu Pasif Olarak Güncellendi");
        }

        [HttpPut("ChangeStatusToTrue/{id}")]
        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            _productRepository.ProductStatusChangeToTrue(id);
            return Ok("İlan Durumu Aktif Olarak Güncellendi");
        }

        [HttpGet("LastFiveProducts")]
        public async Task<IActionResult> LastFiveProducts()
        {
            var values = await _productRepository.GetLastFiveProductsWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("ActiveProductAdvertsListByEmployee")]
        public async Task<IActionResult> ActiveProductAdvertsListByEmployee(int id)
        {
            var values = await _productRepository.GetActiveProductAdvertListByEmployeeAsyn(id);
            return Ok(values);
        }

        [HttpGet("PassiveProductAdvertsListByEmployee")]
        public async Task<IActionResult> PassiveProductAdvertsListByEmployee(int id)
        {
            var values = await _productRepository.GetPassiveProductAdvertListByEmployeeAsyn(id);
            return Ok(values);
        }

        [HttpGet("LastFiveProductsByEmployee")]
        public async Task<IActionResult> LastFiveProductsByEmployee(int id)
        {
            var values = await _productRepository.GetLastFiveProductsByIdWithCategoryAsync(id);
            return Ok(values);
        }

        [HttpGet("ProductSearchList")]
        public async Task<IActionResult> ProductSearchList(string? searchValue, int propertyCategoryId, string? city)
        {
            var values = await _productRepository.ResultProductWithSearchList(searchValue, propertyCategoryId, city);
            return Ok(values);
        }
    }
}
