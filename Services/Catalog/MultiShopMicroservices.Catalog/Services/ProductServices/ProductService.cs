using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservices.Catalog.Dtos.ProductDtos;
using MultiShopMicroservices.Catalog.Entities;
using MultiShopMicroservices.Catalog.Settings;

namespace MultiShopMicroservices.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _productCollection.DeleteOneAsync(p => p.ProductId == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var products = await _productCollection.Find(p => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string productId)
        {
            var product = await _productCollection.Find(p => p.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(p => p.ProductId == updateProductDto.ProductId, product);
        }
    }
}
