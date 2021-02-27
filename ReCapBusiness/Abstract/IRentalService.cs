using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> Get(int rentalId);
        IDataResult<List<Rental>> GetAll();
    }
}
