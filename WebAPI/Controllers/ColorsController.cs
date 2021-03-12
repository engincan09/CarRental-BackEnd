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
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        //All color
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }

        //Color by id
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetColor(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //Add
        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Delete
        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Update
        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }
    }
}
