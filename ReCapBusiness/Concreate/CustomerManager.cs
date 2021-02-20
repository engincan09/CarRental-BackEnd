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
            _customer.Add(customer);
            return new SuccessResult(Messages.AddedMessage);
        }

        public IResult Delete(Customer customer)
        {
            _customer.Delete(customer);
            return new SuccessResult(Messages.DeletedMessage);
        }

        public IDataResult<Customer> Get(int customerId)
        {
            return new SuccessDataResult<Customer>(_customer.Get(m => m.Id == customerId));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customer.GetAll(), Messages.ListedMessage);
        }

        public IResult Update(Customer customer)
        {
            _customer.Update(customer);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}
