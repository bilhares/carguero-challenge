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
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Post([FromBody]AddressDto address)
        {
            var registered = await _addressService.Register(address);

            if (!registered)
                return BadRequest();

            return Ok(address);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> Put([FromBody]AddressDto address, int id)
        {
            var registered = await _addressService.Update(address, id);

            if (!registered)
                return BadRequest();

            return Ok(address);
        }
    }
}