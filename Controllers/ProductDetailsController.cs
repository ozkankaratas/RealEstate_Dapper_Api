using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductDetailsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetProductDetailById")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var values = await _productRepository.GetProductDetailById(id);
            return Ok(values);
        }

        [HttpPost("{ProductId}")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto, int ProductId)
        {
            await _productRepository.CreateProductDetail(createProductDetailDto, ProductId);
            return Ok("İlan Detayı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            await _productRepository.DeleteProductDetail(id);
            return Ok("İlan Detayı Başarılı Bir Şekilde Silindi");
        }

        [HttpPut("{ProductId}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto, int ProductId)
        {
            await _productRepository.UpdateProductDetail(updateProductDetailDto, ProductId);
            return Ok("İlan Detayı Başarılı Bir Şekilde Güncellendi");
        }
    }
}
