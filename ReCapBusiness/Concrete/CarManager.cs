using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectCore.Aspects.Autofac.Caching;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _car;
        private readonly ICarImageService _carImage;

     
        public CarManager(ICarDal car, ICarImageService carImage)
        {
            _car = car;
            _carImage = carImage;
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            _car.Add(car);
            return new SuccessResult(Messages.AddedMessage);
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Car car)
        {
            _car.Delete(car);
            return new SuccessResult(Messages.DeletedMessage);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<List<CarDetailDto>> GetByBrandAndColor(int brandId, int colorId)
        {
            var carDetails = _car.GetCarsDetail(m => m.BrandId == brandId && m.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(carDetails);
        }

        public IDataResult<List<CarDetailDto>> GetByBrandCar(int brandId)
        {
            var carDetails = _car.GetCarsDetail(m => m.BrandId == brandId);
            return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.ListedMessage);
        }

        public IDataResult<List<CarDetailDto>> GetByColorCar(int colorId)
        {
            var carDetails = _car.GetCarsDetail(m=> m.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.ListedMessage);
        }

        public IDataResult<List<Car>> GetByDesc(string desc)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(p => p.Description.ToLower().Contains(desc.ToLower())));
        }

        public IDataResult<Car> GetCar(int id)
        {
            return new SuccessDataResult<Car>(_car.Get(p => p.Id == id));
        }

        public IDataResult<CarDetailAndImageDto> GetCarDetailAndImage(int carId)
        {
            var result = _car.GetCarDetail(carId);
            var image = _carImage.GetAllByCarId(carId);
            if (result == null || image.Success == false)
            {
                return new ErrorDataResult<CarDetailAndImageDto>();
            }
            var carDetailAndImageDto = new CarDetailAndImageDto()
            {
                Car = result,
                Images = image.Data
            };
            return new SuccessDataResult<CarDetailAndImageDto>(carDetailAndImageDto);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarsDetail());
        }



        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _car.Update(car);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}
