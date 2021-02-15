using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concreate;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using ReCapProjectEntities.DTOs;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length >=2 && car.DailyPrice >0)
            {
                _car.Add(car);
                return new SuccessResult(Messages.AddedMessage);
            }
            else
            {
                return new ErrorResult(Messages.AddedErrorMessage);
            }
        }

        public IResult Delete(Car car)
        {
            try
            {
                _car.Delete(car);
                return new SuccessResult(Messages.DeletedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DeletedErrorMessage);
            }
          
        }

        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_car.GetAll(), Messages.ListedMessage);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Car>>(Messages.ListedErrorMessage);
            }
            
        }

        public IDataResult<List<Car>> GetByBrandCar(int brandId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_car.GetAll(p => p.BrandId == brandId), Messages.ListedMessage);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Car>>(Messages.ListedErrorMessage);

            }
            
        }

        public IDataResult<List<Car>> GetByColorCar(int colorId)
        {
            try
            {
                
                return new SuccessDataResult<List<Car>>(_car.GetAll(p => p.ColorId == colorId), Messages.ListedMessage);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Car>>(Messages.ListedErrorMessage);
            }
        }

        public IDataResult<List<Car>> GetByDesc(string desc)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_car.GetAll(p=> p.Description.ToLower().Contains(desc.ToLower())));
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Car>>(Messages.ListedErrorMessage);
            }
        }

        public IDataResult<Car> GetCar(int id)
        {
            try
            {
                return new SuccessDataResult<Car>(_car.Get(p => p.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Car>(Messages.ListedErrorMessage);
            }
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

        public IResult Update(Car car)
        {
            try
            {
                _car.Update(car);
                return new SuccessResult(Messages.UpdatedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UpdatedErrorMessage);
            }
          
        }
    }
}
