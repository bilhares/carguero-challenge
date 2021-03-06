using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressRegister.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _userService.ListUsers());
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody]UserDto user)
        {          
            await _userService.Register(user);

            if (user == null)
                return BadRequest();

            return Ok(user);
        }

    }
}