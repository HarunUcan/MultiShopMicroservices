using MultiShopMicroservices.Cargo.DataAccessLayer.Abstract;
using MultiShopMicroservices.Cargo.DataAccessLayer.Concrete;
using MultiShopMicroservices.Cargo.DataAccessLayer.Repositories;
using MultiShopMicroservices.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservices.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context) : base(context)
        {
            
        }
    }
}
