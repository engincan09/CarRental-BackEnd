
using ReCapProjectEntities.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Abstract
{
    public interface ICarDal 
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GettAll();
        List<Car> GettByIdBrand(int brandId);
    }
}
