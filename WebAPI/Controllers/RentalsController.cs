using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProjectBusiness.Abstract;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IPaymentService _paymentService;

        public RentalsController(IRentalService rentalService,IPaymentService paymentService)
        {
            _rentalService = rentalService;
            _paymentService = paymentService;
        }

        //All Rental List
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _rentalService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }

        //By ıd rental
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.Get(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Add
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Delete
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Update
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        [HttpPost("payment")]
        public IActionResult Payment(RentalPaymentDto rentalPaymentDto) 
        {
            var payResult = _paymentService.Pay(rentalPaymentDto.Payment);
            if (!payResult.Success)
            {
                return BadRequest(payResult);
            }
            var result = _rentalService.Add(rentalPaymentDto.Rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
