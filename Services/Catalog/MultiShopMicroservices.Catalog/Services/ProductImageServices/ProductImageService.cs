using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservices.Catalog.Dtos.ProductImageDtos;
using MultiShopMicroservices.Catalog.Entities;
using MultiShopMicroservices.Catalog.Settings;

namespace MultiShopMicroservices.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var ProductImage = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(ProductImage);
        }

        public async Task DeleteProductImageAsync(string productImageId)
        {
            await _productImageCollection.DeleteOneAsync(p => p.ProductImageId == productImageId);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var productImages = await _productImageCollection.Find(p => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(productImages);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string productImageId)
        {
            var ProductImage = await _productImageCollection.Find(p => p.ProductImageId == productImageId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(ProductImage);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var ProductImage = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(p => p.ProductImageId == updateProductImageDto.ProductImageId, ProductImage);
        }
    }
}
