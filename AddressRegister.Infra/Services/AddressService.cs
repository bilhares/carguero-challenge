using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IGoogleMapsApiService _googleMapsApiService;

        private readonly IMapper _mapper;

        public AddressService(
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            IGoogleMapsApiService googleMapsApiService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
            _googleMapsApiService = googleMapsApiService;
        }

        public async Task<List<Address>> GetByUsername(string username)
        {
            return await _addressRepository.FindByUsername(username);
        }

        public async Task<bool> Register(AddressDto address)
        {
            var user = await _userRepository.FindById(address.UserId);
            if (user == null)
                return false;

            if (!await AddressFromBrazil(address))
                return false;

            address.User = user;

            var addressRegistered = await _addressRepository.Create(_mapper.Map<Address>(address));
            return addressRegistered != null;
        }

        public async Task<bool> Update(AddressDto address, int id)
        {
            return await _addressRepository.Update(_mapper.Map<Address>(address), id);
        }

        private async Task<bool> AddressFromBrazil(AddressDto address)
        {
            var result = await _googleMapsApiService.FindAddress(address);
            return result.status == "OK";
        }

        public async Task<bool> Delete(string username, int id)
        {
            var address = await _addressRepository.FindById(id);
            if (address == null)
                return false;

            if (address.User.Username != username)
                return false;

            return await _addressRepository.Delete(id);
        }
    }
}
