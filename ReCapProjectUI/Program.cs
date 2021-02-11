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
    

            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.Description + " - " + car.DailyPrice + " - " + car.ModelYear);
                }
                Console.WriteLine(result.Messages);
            }
            else
            {
                Console.WriteLine(result.Messages);
            }
            





        }
    }
}
