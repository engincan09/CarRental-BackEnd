using ReCapProjectCore.DataAccess;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<CarRentalDto> GetRentalDetails();
    }
}
