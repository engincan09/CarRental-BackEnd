
using ReCapProjectEntities.Concreate;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetByBrandCar(int brandId);
        List<Car> GetByColorCar(int colorId);
        List<CarDetailDto> GetCarDetail();
        Car GetCar(int id);
        
    }
}
