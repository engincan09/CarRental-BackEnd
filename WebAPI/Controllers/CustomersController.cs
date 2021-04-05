using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProjectBusiness.Abstract;
using ReCapProjectEntities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //All Customer
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetCustomerDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }

        //Get customer by user id
        [HttpGet("getcustomerbyuserid")]
        public IActionResult GetById(int userId)
        {
            var result = _customerService.Get(userId);          
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //Add customer
        [HttpPost("add")]
        public IActionResult Add(Customer customer )
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Delet customer
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Update customer
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }
    }
}
