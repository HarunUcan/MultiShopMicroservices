using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Cargo.BusinessLayer.Abstract;
using MultiShopMicroservices.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShopMicroservices.Cargo.EntityLayer.Concrete;

namespace MultiShopMicroservices.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var result = _cargoOperationService.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoOperationDto createCargoOperationDto)
        {
            _cargoOperationService.TInsert(new CargoOperation
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            });
            return Ok("Kargo operasyonu başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoOperationService.TDelete(id);
            return  Ok("Kargo operasyonu başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoOperationDto updateCargoOperationDto)
        {
            _cargoOperationService.TUpdate(new CargoOperation
            {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            });
            return Ok("Kargo operasyonu başarıyla güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var result = _cargoOperationService.TGetById(id);
            return Ok(result);
        }
    }
}
