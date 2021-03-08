using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Interfaces
{
    public interface IAddressService
    {
        Task<bool> Register(AddressDto address);
        Task<bool> Update(AddressDto address, int id);
        Task<List<Address>> GetByUsername(string username);
        Task<bool> Delete(string username, int id);
    }
}
