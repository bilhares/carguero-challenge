using AddressRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<List<User>> GetAll();
        User GetByUsername(string username);
    }
}
