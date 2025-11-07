using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservices.Cargo.BusinessLayer.Abstract;
using MultiShopMicroservices.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShopMicroservices.Cargo.EntityLayer.Concrete;

namespace MultiShopMicroservices.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var result = _cargoCompanyService.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            _cargoCompanyService.TInsert(new CargoCompany
            {
                CompanyName = createCargoCompanyDto.CompanyName
            });
            return Ok("Kargo şirketi başarıyla oluşturuldu!");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            _cargoCompanyService.TUpdate(new CargoCompany
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CompanyName = updateCargoCompanyDto.CompanyName
            });
            return Ok("Kargo şirketi başarıyla güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var result = _cargoCompanyService.TGetById(id);
            return Ok(result);
        }
    }
}
