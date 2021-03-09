using AddressRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressRegister.Domain.Dtos
{
    public class AddressDto
    {
        public string ZipCode { get;  set; }
        public int Number { get;  set; }
        public string City { get;  set; }
        public string District { get;  set; }
        public string Complement { get;  set; }
        public string State { get;  set; }
        public int UserId { get;  set; }
        public User User { get; set; }

        public AddressDto()
        {
        }

        public AddressDto(string zipCode, int number, string city, string district, string complement, string state, int userId)
        {
            ZipCode = zipCode;
            Number = number;
            City = city;
            District = district;
            Complement = complement;
            State = state;
            UserId = userId;
        }
    }
}
