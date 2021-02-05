using ReCapProjectBusiness.Abstract;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.ConCreate;
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

        public void Add(Car car)
        {
            if (car.Description.Length >=2 && car.DailyPrice >0)
            {
                _car.Add(car);
                Console.WriteLine("Araç Ekleme İşlemi Başarılı!");
            }
            else
            {
                Console.WriteLine("Araba eklenemedi. Fiyat 0 TL'den küçük olamaz veya açıklama en az 2 karakter olmalıdır. ");
            }
        }

        public void Delete(Car car)
        {
            _car.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _car.GetAll();
        }

        public List<Car> GetByBrandCar(int brandId)
        {
            return _car.GetAll(p=> p.BrandId == brandId);
        }

        public List<Car> GetByColorCar(int colorId)
        {
            return _car.GetAll(p=> p.ColorId == colorId);
        }

        public Car GetCar(int id)
        {
            return _car.Get(p => p.Id == id);
        }

        public void Update(Car car)
        {
            _car.Update(car);
        }
    }
}
