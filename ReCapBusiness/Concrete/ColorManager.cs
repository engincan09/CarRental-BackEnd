using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.BusinessAspect.Autofac;
using ReCapProjectBusiness.Constants;
using ReCapProjectBusiness.ValidationRules.FluentValidation;
using ReCapProjectCore.Aspects.Autofac.Caching;
using ReCapProjectCore.Aspects.Autofac.Validation;
using ReCapProjectCore.Utilities.Business;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReCapProjectBusiness.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _color;

        public ColorManager(IColorDal color)
        {
            _color = color;
        }
        [CacheRemoveAspect("IColorService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckColorName(color.Name));
            if (result != null)
            {
                return result;
            }
            _color.Add(color);
            return new SuccessResult(Messages.AddedMessage);
        }
        [CacheRemoveAspect("IColorService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("admin")]
        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(Messages.DeletedMessage);
        }
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll(), Messages.ListedMessage);
        }
        [CacheAspect]
        public IDataResult<Color> GetColor(int id)
        {
            return new SuccessDataResult<Color>(_color.Get(p => p.Id == id));
        }
        [CacheRemoveAspect("IColorService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        //[SecuredOperation("admin")]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CheckColorName(color.Name));
            if (result != null)
            {
                return result;
            }
            _color.Update(color);
            return new SuccessResult(Messages.UpdatedMessage);
        }

        private IResult CheckColorName(string colorName)
        {
            var result = _color.GetAll(p=> p.Name == colorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameError);
            }
            return new SuccessResult();
        }
    }
}
