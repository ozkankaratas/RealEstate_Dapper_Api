using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsyn();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetActiveProductAdvertListByEmployeeAsyn(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetPassiveProductAdvertListByEmployeeAsyn(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetLastFiveProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetLastFiveProductsByIdWithCategoryAsync(int id);
        Task CreateProduct(CreateProductDto createProductDto);
        Task CreateProductDetail(CreateProductDetailDto createProductDetailDto, int id);
        Task DeleteProduct(int id);
        Task DeleteProductDetail(int id);
        Task UpdateProduct(UpdateProductDto updateProductDto);
        Task UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto, int id);
        Task<GetByIDProductDto> GetProductById(int id);
        Task<GetProductDetailByIdDto> GetProductDetailById(int id);
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task ProductStatusChangeToTrue(int id);
        Task ProductStatusChangeToFalse(int id);
    }
}
