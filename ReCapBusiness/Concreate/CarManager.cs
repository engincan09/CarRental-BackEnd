using ReCapProjectBusiness.Abstract;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concreate
{
    public class CarManager : ICarService
    {
        ICarDal _car;
        public CarManager(ICarDal car)
        {
            _car = car;
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            _car.Delete(car);
        }

        public List<Car> GettAll()
        {
            return _car.GettAll();
        }

        public List<Car> GettByIdBrand(int brandId)
        {
            return _car.GettByIdBrand(brandId);
        }

        public void Update(Car car)
        {
            _car.Update(car);
        }
    }
}
