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
    public class ColorManager : IColorService
    {
        IColorDal _color;

        public ColorManager(IColorDal color)
        {
            _color = color;
        }

        public IResult Add(Color color)
        {
            try
            {
                _color.Add(color);
                return new SuccessResult(Messages.AddedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.AddedErrorMessage);
            }
        }

        public IResult Delete(Color color)
        {
            try
            {
                _color.Delete(color);
                return new SuccessResult(Messages.DeletedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DeletedErrorMessage);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_color.GetAll(),Messages.ListedMessage);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Color>>(Messages.ListedErrorMessage);
            }
        }

        public IDataResult<Color> GetColor(int id)
        {
            try
            {
                return new SuccessDataResult<Color>(_color.Get(p=> p.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Color>();
            }
        }

        public IResult Update(Color color)
        {
            try
            {
                _color.Update(color);
                return new SuccessResult(Messages.UpdatedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UpdatedErrorMessage);
            }
        }
    }
}
