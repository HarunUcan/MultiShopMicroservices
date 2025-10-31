using MultiShopMicroservices.Catalog.Dtos.ProductImageDtos;

namespace MultiShopMicroservices.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string productImageId);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId);
    }
}
