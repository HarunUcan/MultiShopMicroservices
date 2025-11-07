using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Basket.Dtos;
using MultiShopMicroservices.Basket.LoginServices;
using MultiShopMicroservices.Basket.Services;

namespace MultiShopMicroservices.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;
            var userId = _loginService.GetUserId;
            var basket = await _basketService.GetBasket(userId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepet kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = _loginService.GetUserId;
            await _basketService.DeleteBasket(userId);
            return Ok("Sepet silindi.");
        }
    }
}
