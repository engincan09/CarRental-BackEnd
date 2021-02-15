
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectEntities.Concreate;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandCar(int brandId);
        IDataResult<List<Car>> GetByColorCar(int colorId);
        IDataResult<List<Car>> GetByDesc(string desc);
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<Car> GetCar(int id);
        
    }
}
