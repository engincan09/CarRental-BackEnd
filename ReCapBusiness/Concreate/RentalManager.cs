using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concreate;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concreate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rental;

        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }

        public IResult Add(Rental rental)
        {
            var rentalList = _rental.GetAll(m => m.CarId == rental.CarId);
            foreach (var car in rentalList)
            {
                if (car.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalError);
                }
            }
            _rental.Add(rental);
            return new SuccessResult(Messages.Rental);
        }

        public IResult Delete(Rental rental)
        {
            try
            {
                _rental.Delete(rental);
                return new SuccessResult(Messages.DeletedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DeletedErrorMessage);
            }
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            try
            {
                return new SuccessDataResult<Rental>(_rental.Get(m=> m.Id == rentalId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Rental>(Messages.ListedErrorMessage);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rental.GetAll());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Rental>>(Messages.ListedErrorMessage);
            }
        }

        public IResult Update(Rental rental)
        {
            try
            {
                _rental.Update(rental);
                return new SuccessResult(Messages.UpdatedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UpdatedErrorMessage);
            }
        }
    }
}
