using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Context;
using AddressRegister.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Respositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressRegisterDbContext _context;
        public AddressRepository(AddressRegisterDbContext context)
        {
            _context = context;
        }
        public async Task<Address> Create(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<bool> Update(Address address, int id)
        {
            var addressRegistered = await FindById(id);

            addressRegistered.UpdateComplement(address.Complement);
            addressRegistered.UpdateNumber(address.Number);

            _context.Addresses.Update(addressRegistered);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var addressRegistered = await FindById(id);
            _context.Remove(addressRegistered);

            return (await _context.SaveChangesAsync()) > 0;
        }

        public Task<List<Address>> FindByUsername(string username)
        {
            return _context.Addresses.Where(x => x.User.Username == username)
                .Include(_ => _.User).ToListAsync();
        }
        public async Task<Address> FindById(int id)
        {
            return await _context.Addresses.Where(x => x.Id == id)
                .Include(_ => _.User).FirstOrDefaultAsync();
        } 
    }
}
