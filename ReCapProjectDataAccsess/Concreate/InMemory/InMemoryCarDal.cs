using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProjectDataAccsess.Concreate.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=2,ColorId=1, DailyPrice=250,ModelYear=2000,Description="Orijinal konforlu"},
                new Car{Id=2,BrandId=2,ColorId=4, DailyPrice=350,ModelYear=2010,Description="Klimasız"},
                 new Car{Id=3,BrandId=4,ColorId=2, DailyPrice=150,ModelYear=2008,Description="Klimalı"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }



        public List<Car> GettByIdBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car deleteCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            deleteCar.BrandId = car.BrandId;
            deleteCar.ColorId = car.ColorId;
            deleteCar.DailyPrice = car.DailyPrice;
            deleteCar.Description = car.Description;
            deleteCar.ModelYear = car.ModelYear;
        }
    }

}
