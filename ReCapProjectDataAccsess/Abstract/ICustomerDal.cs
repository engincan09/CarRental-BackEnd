using ReCapProjectCore.DataAccess;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetails();
    }
}
