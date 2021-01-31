using ReCapProjectBusiness.Concreate;
using ReCapProjectDataAccsess.Concreate.InMemory;
using ReCapProjectEntities.Concreate;
using System;

namespace ReCapProjectUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

           
      
            carManager.Add(new Car { Id = 4, BrandId = 4, ColorId = 2, DailyPrice = 150, ModelYear = 2008, Description = "Otomatik Vites" });
            carManager.Update(new Car { Id = 1,Description="ARABA YOK" });
            carManager.Delete(new Car { Id = 1 });



   
            Console.WriteLine("Markası 4 numaralı Id olan araçlar");
            Console.WriteLine("--------------------------------------");
            foreach (var brandId in carManager.GettByIdBrand(4) )
            {
                Console.WriteLine("Araç: " + brandId.Id + " "+ "Marka:"+" "+brandId.BrandId  + " - "+brandId.Description);
            }
            Console.WriteLine("===");

            Console.WriteLine("Bütün araçlar");
            Console.WriteLine("--------------------------------------");
            foreach (var car in carManager.GettAll())
            {
                Console.WriteLine("Araç: " + car.Id+ "- "+car.Description);
            }
        }
    }
}
