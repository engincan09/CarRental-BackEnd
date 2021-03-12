using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.BusinessAspect.Autofac;
using ReCapProjectBusiness.Constants;
using ReCapProjectBusiness.ValidationRules.FluentValidation;
using ReCapProjectCore.Aspects.Autofac.Caching;
using ReCapProjectCore.Aspects.Autofac.Validation;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customer;

        public CustomerManager(ICustomerDal customer)
        {
            _customer = customer;
        }
        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Customer customer)
        {
            _customer.Add(customer);
            return new SuccessResult(Messages.AddedMessage);
        }
        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin")]
        public IResult Delete(Customer customer)
        {
            _customer.Delete(customer);
            return new SuccessResult(Messages.DeletedMessage);
        }
        [CacheAspect]
        public IDataResult<Customer> Get(int customerId)
        {
            return new SuccessDataResult<Customer>(_customer.Get(m => m.Id == customerId));
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customer.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailDto()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customer.GetCustomerDetails(), Messages.ListedMessage);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin")]
        public IResult Update(Customer customer)
        {
            _customer.Update(customer);
            return new SuccessResult(Messages.UpdatedMessage);
        }

    
    }
}
