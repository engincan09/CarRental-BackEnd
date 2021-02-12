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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customer;

        public CustomerManager(ICustomerDal customer)
        {
            _customer = customer;
        }

        public IResult Add(Customer customer)
        {
            try
            {
                _customer.Add(customer);
                return new SuccessResult(Messages.AddedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.AddedErrorMessage);
            }
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _customer.Delete(customer);
                return new SuccessResult(Messages.DeletedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.DeletedErrorMessage);
            }
        }

        public IDataResult<Customer> Get(int customerId)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customer.Get(m => m.Id == customerId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Customer>(Messages.ListedErrorMessage);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customer.GetAll(),Messages.ListedMessage);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Customer>>(Messages.ListedErrorMessage);
            }
        }

        public IResult Update(Customer customer)
        {
            try
            {
                _customer.Update(customer);
                return new SuccessResult(Messages.UpdatedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UpdatedErrorMessage);
            }
        }
    }
}
