using ReCapProjectCore.DataAccess.EntityFramework;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReCapProjectDataAccsess.Concreate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear };
                return result.ToList();
            }
        }
    }
}
