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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        //All brands
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }

        //Brand by id
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetBrand(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Add brand
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Delete brand
        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Update brand
        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }
    }
}
