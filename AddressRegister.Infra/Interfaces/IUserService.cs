using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(UserDto user);
        Task<List<User>> ListUsers();
        User GetByUsername(string username);
    }
}
