using ReCapProjectBusiness.Abstract;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.ConCreate;
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

        public void Add(Color color)
        {
            _color.Add(color);
            Console.WriteLine("Renk Bilgisi Eklendi");
        }

        public void Delete(Color color)
        {
            _color.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _color.GetAll();
        }

        public Color GetColor(int id)
        {
            return _color.Get(p => p.Id == id);
        }

        public void Update(Color color)
        {
            _color.Update(color);
        }
    }
}
