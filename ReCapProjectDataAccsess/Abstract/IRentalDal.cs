using ReCapProjectCore.DataAccess;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
    }
}
