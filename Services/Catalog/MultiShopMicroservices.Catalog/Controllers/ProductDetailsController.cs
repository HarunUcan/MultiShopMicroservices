using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Catalog.Dtos.ProductDetailDtos;
using MultiShopMicroservices.Catalog.Services.ProductDetailServices;

namespace MultiShopMicroservices.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var productDetails = await _productDetailService.GetAllProductDetailsAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı başarıyla oluşturuldu!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı başarıyla güncellendi!");
        }
    }
}
