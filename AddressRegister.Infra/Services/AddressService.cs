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

        public async Task<bool> Register(AddressDto address)
        {
            var user = _userRepository.findById(address.UserId);
            if (user == null)
                return false;

            if (!await AddressFromBrazil(address))
                return false;

            address.User = user;

            var  addressRegistered = await _addressRepository.Create(_mapper.Map<Address>(address));
            return addressRegistered != null;
        }

        public async Task<bool> Update(AddressDto address, int id)
        {
            return await _addressRepository.Update(_mapper.Map<Address>(address), id);
        }

        private async Task<bool> AddressFromBrazil(AddressDto address)
        {
            var result =  await _googleMapsApiService.FindAddress(address);
            return result.status == "OK";
        }


    }
}
