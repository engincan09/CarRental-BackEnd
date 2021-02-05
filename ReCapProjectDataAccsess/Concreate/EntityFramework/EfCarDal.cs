using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Concreate.EntityFramework
{
    public class EfCarDal : EfEntityRepository<Car,RentACarContext> ,ICarDal
    {
    }
}
