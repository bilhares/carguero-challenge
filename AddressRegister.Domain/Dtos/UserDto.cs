using System;
using System.Collections.Generic;
using System.Text;

namespace AddressRegister.Domain.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }

        public UserDto()
        {
        }

        public UserDto(string username)
        {
            Username = username;
        }
    }
}
