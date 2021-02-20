using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectBusiness.ValidationRules.FluentValidation;
using ReCapProjectCore.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brand.Add(brand);
            return new SuccessResult(Messages.AddedMessage);

        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult(Messages.DeletedMessage);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<Brand> GetBrand(int id)
        {
            return new SuccessDataResult<Brand>(_brand.Get(m => m.Id == id));
        }

        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}
