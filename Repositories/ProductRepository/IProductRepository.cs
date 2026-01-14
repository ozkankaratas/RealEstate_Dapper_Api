using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsyn();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetLastFiveProductsWithCategoryAsync();
        void CreateProduct(CreateProductDto createProductDto);
        void DeleteProduct(int id);
        void UpdateProduct(UpdateProductDto updateProductDto);
        Task<GetByIDProductDto> GetProduct(int id);
        void ProductDealOfTheDayStatusChangeToTrue(int id);
        void ProductDealOfTheDayStatusChangeToFalse(int id);
    }
}
