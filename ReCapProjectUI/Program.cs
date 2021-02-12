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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental {CarId=2,CustomerId=1,RentDate=DateTime.Now.Date});

            if (result.Success == true)
            {
                Console.WriteLine(result.Messages);
            }
            else
            {
                Console.WriteLine(result.Messages);
            }


        }
    }
}
