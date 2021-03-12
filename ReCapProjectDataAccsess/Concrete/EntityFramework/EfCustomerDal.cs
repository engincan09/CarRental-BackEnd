using ReCapProjectCore.DataAccess.EntityFramework;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReCapProjectDataAccsess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto { FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName, CustomerId = c.Id };
                return result.ToList();

            }
        }

    }
}
