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
        public CarManager(ICarDal car)
        {
            _car = car;
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

        public IDataResult<List<Car>> GetByBrandCar(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(p => p.BrandId == brandId), Messages.ListedMessage);
        }

        public IDataResult<List<Car>> GetByColorCar(int colorId)
        {

            return new SuccessDataResult<List<Car>>(_car.GetAll(p => p.ColorId == colorId), Messages.ListedMessage);
        }

        public IDataResult<List<Car>> GetByDesc(string desc)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(p => p.Description.ToLower().Contains(desc.ToLower())));
        }

        public IDataResult<Car> GetCar(int id)
        {
            return new SuccessDataResult<Car>(_car.Get(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetail());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ListedErrorMessage);
            }
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _car.Update(car);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}
