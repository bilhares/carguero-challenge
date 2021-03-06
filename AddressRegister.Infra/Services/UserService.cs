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

        public Task<List<User>> ListUsers()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> Register(UserDto user)
        {
            if (UserAlreadyRegistered(user.Username))
                return null;

            return await _userRepository.Create(_mapper.Map<User>(user));
        }

        private bool UserAlreadyRegistered(string username)
        {
            var user = _userRepository.GetByUsername(username);
            return user != null;
        }
    }
}
