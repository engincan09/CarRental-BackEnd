using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProjectBusiness.Abstract;
using ReCapProjectEntities.Concreate;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        //All cars
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Details of all cars
        [HttpGet]
        public IActionResult GettCarDetails()
        {
            var result = _carService.GetCarDetail();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Car by ID
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetCar(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Car by Color
        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int id)
        {
            var result = _carService.GetByColorCar(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Car by Brand
        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int id)
        {
            var result = _carService.GetByBrandCar(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Car by Description
        [HttpGet("getbydesc")]
        public IActionResult GetByDesc(string desc)
        {
            var result = _carService.GetByDesc(desc);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);

        }

        //Add Car
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Delete Car
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Update Car
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }



    }
}
