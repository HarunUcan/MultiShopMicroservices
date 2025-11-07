using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Cargo.BusinessLayer.Abstract;
using MultiShopMicroservices.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShopMicroservices.Cargo.EntityLayer.Concrete;

namespace MultiShopMicroservices.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var result = _cargoDetailService.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            _cargoDetailService.TInsert(new CargoDetail
            {
                Barcode = createCargoDetailDto.Barcode,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCusomerId = createCargoDetailDto.SenderCusomerId,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId
            });
            return Ok("Kargo detayları başarıyla oluşturuldu!");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayları başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            _cargoDetailService.TUpdate(new CargoDetail
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCusomerId = updateCargoDetailDto.SenderCusomerId,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId
            });
            return Ok("Kargo detayları başarıyla güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var result = _cargoDetailService.TGetById(id);
            return Ok(result);
        }
    }
}
