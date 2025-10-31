using MultiShopMicroservices.Catalog.Dtos.ProductDetailDtos;

namespace MultiShopMicroservices.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string productDetailId);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId);
    }
}
