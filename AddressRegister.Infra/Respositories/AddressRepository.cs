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
            var addressRegistered = GetById(id);

            addressRegistered.UpdateComplement(address.Complement);
            addressRegistered.UpdateNumber(address.Number);

            _context.Addresses.Update(addressRegistered);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var addressRegistered = GetById(id);
            _context.Remove(addressRegistered);

            return (await _context.SaveChangesAsync()) > 0;
        }

        public Task<List<Address>> GetByUsername(string username)
        {
            return _context.Addresses.Where(x => x.User.Username == username)
                .Include(_ => _.User).ToListAsync();
        }
        private Address GetById(int id)
        {
            return _context.Addresses.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
