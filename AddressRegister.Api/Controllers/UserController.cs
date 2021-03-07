
using System.Collections.Generic;
using System.Threading.Tasks;
using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressRegister.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
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
            var registered = await _userService.Register(user);

            if (!registered)
                return BadRequest();

            return Ok(user);
        }

        [HttpGet]
        [Route("GetByUsername")]
        public async Task<ActionResult<List<User>>> GetByUsername([FromQuery]string username)
        {
            var user = _userService.GetByUsername(username);
            return Ok(user);
        }
    }
}