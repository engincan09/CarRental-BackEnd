using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProjectBusiness.Abstract;
using ReCapProjectCore.Entities.Concrete;
using ReCapProjectEntities.Concrete;
using ReCapProjectEntities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //All User
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }

        //User
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.Get(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Messages);
        }
      
        //Add
        [HttpGet("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //delete
        [HttpGet("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            return BadRequest(result.Messages);
        }

        //Update
        [HttpPost("update")]
        public IActionResult Update(UserForUpdateDto userForUpdate)
        {
            var result = _userService.Update(userForUpdate.User,userForUpdate.Password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //Get Claim
        [HttpGet("getclaim")]
        public IActionResult GetClaim(User user)
        {
            var result = _userService.GetClaims(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        //Get User  
        [HttpGet("getuser")]
        public IActionResult GetUser(string email) 
        {
            var result = _userService.GetUserAndClaim(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //Get By Email
        [HttpGet("getbyemail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
