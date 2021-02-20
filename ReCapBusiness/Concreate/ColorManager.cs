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
        private readonly IColorDal _color;

        public ColorManager(IColorDal color)
        {
            _color = color;
        }

        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(Messages.AddedMessage);
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(Messages.DeletedMessage);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<Color> GetColor(int id)
        {
            return new SuccessDataResult<Color>(_color.Get(p => p.Id == id));
        }

        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}
