using ReCapProjectBusiness.Concreate;
using ReCapProjectDataAccsess.Concreate.EntityFramework;
using ReCapProjectDataAccsess.Concreate.InMemory;
using ReCapProjectEntities.ConCreate;
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

            carManager.Add(new Car { BrandId=1,ColorId=1,DailyPrice=250,ModelYear=2014,Description="Klimalı,Dizel,Otomatik"});

          
      
        }
    }
}
