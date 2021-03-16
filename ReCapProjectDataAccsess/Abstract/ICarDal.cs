

using ReCapProjectCore.DataAccess;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProjectDataAccsess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetail(int id);
       
    }
}
