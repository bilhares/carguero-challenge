using AddressRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> Create(Address address);
        Task<bool> Update(Address address, int id);
        Task<bool> Delete(int id);  
        Task<List<Address>> GetByUsername(string username);
    }
}
