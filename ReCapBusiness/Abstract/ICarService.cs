
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectEntities.Concrete;
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
        IDataResult<List<CarDetailDto>> GetByBrandCar(int brandId);
        IDataResult<List<CarDetailDto>> GetByColorCar(int colorId);
        IDataResult<List<Car>> GetByDesc(string desc);
        IDataResult<List<CarDetailDto>> GetCarsDetail();
        IDataResult<CarDetailAndImageDto> GetCarDetailAndImage(int carId);
        IDataResult<Car> GetCar(int id);
        
    }
}
