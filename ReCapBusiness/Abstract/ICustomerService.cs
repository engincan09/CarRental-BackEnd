using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> Get(int customerId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetailDto();

    }
}
