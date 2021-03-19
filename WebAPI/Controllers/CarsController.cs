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
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        //All cars
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetCarsDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail(int carId)
        {
            var result = _carService.GetCarDetailAndImage(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }
        [HttpGet("getbybrandandcolor")]
        public IActionResult GetByBrandAndColor(int brandId,int colorId) 
        {
            var result = _carService.GetByBrandAndColor(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
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
        public IActionResult GetByColor(int colorId)
        {
            var result = _carService.GetByColorCar(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }

        //Car by Brand
        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _carService.GetByBrandCar(brandId);
            if (result.Success)
            {
                return Ok(result);
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
