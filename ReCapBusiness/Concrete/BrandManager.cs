using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.BusinessAspect.Autofac;
using ReCapProjectBusiness.Constants;
using ReCapProjectBusiness.ValidationRules.FluentValidation;
using ReCapProjectCore.Aspects.Autofac.Caching;
using ReCapProjectCore.Aspects.Autofac.Validation;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brand;

        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }

        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brand.Add(brand);
            return new SuccessResult(Messages.AddedMessage);

        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult(Messages.DeletedMessage);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(), Messages.ListedMessage);
        }
        [CacheAspect]
        public IDataResult<Brand> GetBrand(int id)
        {
            return new SuccessDataResult<Brand>(_brand.Get(m => m.Id == id));
        }
        [ValidationAspect(typeof(BrandValidator))]
        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult(Messages.UpdatedMessage);
        }

        
    }
}
