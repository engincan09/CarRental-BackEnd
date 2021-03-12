using ReCapProjectCore.DataAccess.EntityFramework;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<CarRentalDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join u in context.Users on cu.UserId equals u.Id
                             select new CarRentalDto {RentalId=r.Id,CarName = b.Name,CustomerLastName=u.LastName,CustomerFirstName = u.FirstName,RentDate=r.RentDate,ReturnDate=r.ReturnDate};
                return result.ToList();
                             
            }
        }
    }
}
