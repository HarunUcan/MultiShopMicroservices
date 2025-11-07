using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservices.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class CreateCargoDetailDto
    {
        public string SenderCusomerId { get; set; } // MongoDB'den alınacak
        public string ReceiverCustomer { get; set; } // MongoDB'den alınacak
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
