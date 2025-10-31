using MultiShopMicroservices.Catalog.Dtos.CategoryDtos;

namespace MultiShopMicroservices.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryId);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId);
    }
}
