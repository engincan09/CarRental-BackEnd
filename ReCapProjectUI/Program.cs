using ReCapProjectBusiness.Concreate;
using ReCapProjectDataAccsess.Concreate.EntityFramework;
using ReCapProjectDataAccsess.Concreate.InMemory;
using ReCapProjectEntities.Concreate;
using System;

namespace ReCapProjectUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.Description + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice + " - " + car.ModelYear);
            }

          
      
        }
    }
}
