using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _userRepository.FindByUsername(username);
        }

        public Task<List<User>> ListUsers()
        {
            return _userRepository.FindAll();
        }

        public async Task<bool> Register(UserDto user)
        {
            if (await UserAlreadyRegistered(user.Username))
                return false;

            var userRegistered = await _userRepository.Create(_mapper.Map<User>(user));
            return userRegistered != null;
        }

        private async Task<bool> UserAlreadyRegistered(string username)
        {
            var user = await _userRepository.FindByUsername(username);
            return user != null;
        }
    }
}
