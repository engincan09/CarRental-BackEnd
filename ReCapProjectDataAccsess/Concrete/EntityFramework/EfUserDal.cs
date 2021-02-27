using ReCapProjectCore.DataAccess.EntityFramework;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,RentACarContext>,IUserDal
    {
    }
}
