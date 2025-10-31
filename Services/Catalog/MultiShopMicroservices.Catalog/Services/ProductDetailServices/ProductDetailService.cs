using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservices.Catalog.Dtos.ProductDetailDtos;
using MultiShopMicroservices.Catalog.Entities;
using MultiShopMicroservices.Catalog.Settings;

namespace MultiShopMicroservices.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var ProductDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(ProductDetail);
        }

        public async Task DeleteProductDetailAsync(string productDetailId)
        {
            await _productDetailCollection.DeleteOneAsync(p => p.ProductDetailId == productDetailId);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            var productDetails = await _productDetailCollection.Find(p => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId)
        {
            var ProductDetail = await _productDetailCollection.Find(p => p.ProductDetailId == productDetailId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(ProductDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var ProductDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(p => p.ProductDetailId == updateProductDetailDto.ProductDetailId, ProductDetail);
        }
    }
}
