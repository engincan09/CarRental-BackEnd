using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.BusinessAspect.Autofac;
using ReCapProjectBusiness.Constants;
using ReCapProjectBusiness.ValidationRules.FluentValidation;
using ReCapProjectCore.Aspects.Autofac.Validation;
using ReCapProjectCore.Utilities.Business;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rental;


        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }

        [ValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("admin")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckRental(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rental.Add(rental);
            return new SuccessResult(Messages.Rental);
        }
        [SecuredOperation("admin")]
        public IResult Delete(Rental rental)
        {
            _rental.Delete(rental);
            return new SuccessResult(Messages.DeletedMessage);
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rental.Get(m => m.Id == rentalId));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll());
        }

        public IDataResult<List<CarRentalDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDto>>(_rental.GetRentalDetails());
        }

        [SecuredOperation("admin")]
        public IResult Update(Rental rental)
        {
            _rental.Update(rental);
            return new SuccessResult(Messages.UpdatedMessage);
        }

        private IResult CheckRental(int carId)
        {
            var rentalList = _rental.GetAll(m => m.CarId == carId);
            foreach (var car in rentalList)
            {
                if (car.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalError);
                }
            }
            return new SuccessResult();
        }

    }
}
