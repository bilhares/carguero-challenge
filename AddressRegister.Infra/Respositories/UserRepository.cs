using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Context;
using AddressRegister.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AddressRegisterDbContext _context;

        public UserRepository(AddressRegisterDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public User findByUsername(string username)
        {
            return _context.Users.Where(_ => _.Username == username).FirstOrDefault();
        }

        public User findById(int id)
        {
            return _context.Users.Where(_ => _.Id == id).FirstOrDefault();
        }
    }
}
