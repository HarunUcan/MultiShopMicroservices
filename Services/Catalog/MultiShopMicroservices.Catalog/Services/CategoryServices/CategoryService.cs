using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservices.Catalog.Dtos.CategoryDtos;
using MultiShopMicroservices.Catalog.Entities;
using MultiShopMicroservices.Catalog.Settings;

namespace MultiShopMicroservices.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await _categoryCollection.DeleteOneAsync(c => c.CategoryId == categoryId);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId)
        {
            var category = await _categoryCollection.Find(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var updatedCategory = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(c => c.CategoryId == updateCategoryDto.CategoryId, updatedCategory);
        }
    }
}
