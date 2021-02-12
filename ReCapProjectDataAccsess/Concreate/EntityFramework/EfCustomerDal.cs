using ReCapProjectCore.DataAccess.EntityFramework;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Concreate.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
    }
}
