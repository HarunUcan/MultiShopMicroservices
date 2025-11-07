using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservices.Cargo.DtoLayer.Dtos.CargoCompanyDtos
{
    public class UpdateCargoCompanyDto
    {
        public int CargoCompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
