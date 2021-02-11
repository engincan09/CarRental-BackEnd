using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concreate;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concreate
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;

        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }

        public IResult Add(Brand brand)
        {
            try
            {
                _brand.Add(brand);
                return new SuccessResult(Messages.AddedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.AddedErrorMessage);
            }
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brand.Delete(brand);
                return new SuccessResult(Messages.DeletedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DeletedErrorMessage);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brand.GetAll(),Messages.ListedMessage);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Brand>>(Messages.ListedErrorMessage);
            }
        }

        public IDataResult<Brand> GetBrand(int id)
        {
            try
            {
                return new SuccessDataResult<Brand>(_brand.Get(m => m.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Brand>(Messages.ListedErrorMessage);
            }
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brand.Update(brand);
                return new SuccessResult(Messages.UpdatedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UpdatedErrorMessage);
            }
        }
    }
}
