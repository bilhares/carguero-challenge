using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Interfaces;
using AddressRegister.Infra.Services;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressRegister.Tests.Tests
{
    public class AddressTest
    {
        private Mock<IAddressRepository> _addressRepositoryMock;
        private Mock<IGoogleMapsApiService> _googleMapsApiServiceMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IMapper> _mapperyMock;

        private AddressService _addressService;

        public AddressTest()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _googleMapsApiServiceMock = new Mock<IGoogleMapsApiService>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperyMock = new Mock<IMapper>();

            _addressService = new AddressService(
                _userRepositoryMock.Object,
                _addressRepositoryMock.Object,
                _googleMapsApiServiceMock.Object,
                _mapperyMock.Object
                );
        }

        [Theory]
        [InlineData(1, "felipe.bilhares")]
        public async Task ShouldRegisterAddressFromBrazil(int userId, string username)
        {
            var addressDto = GetAddressDto();
            var address = GetAddress();
            var googleMapApiResult = GetGoogleApiResultOk();

            _userRepositoryMock.Setup(x => x.FindById(userId)).ReturnsAsync(new User(username));
            _googleMapsApiServiceMock.Setup(x => x.FindAddress(addressDto)).ReturnsAsync(googleMapApiResult);
            _addressRepositoryMock.Setup(x => x.Create(address)).ReturnsAsync(address);
            _mapperyMock.Setup(x => x.Map<Address>(It.IsAny<AddressDto>())).Returns(address);

            var registred = await _addressService.Register(addressDto);

            Assert.True(registred);
        }

        [Theory]
        [InlineData(1, "felipe.bilhares")]
        public async Task ShoulNotRegisterAddressNotFromBrazil(int userId, string username)
        {
            var addressDto = GetAddressDto();
            var address = GetAddress();
            var googleMapApiResult = GetGoogleApiResultNotFound();

            _userRepositoryMock.Setup(x => x.FindById(userId)).ReturnsAsync(new User(username));
            _googleMapsApiServiceMock.Setup(x => x.FindAddress(addressDto)).ReturnsAsync(googleMapApiResult);
            _addressRepositoryMock.Setup(x => x.Create(address)).ReturnsAsync(address);
            _mapperyMock.Setup(x => x.Map<Address>(It.IsAny<AddressDto>())).Returns(address);

            var registred = await _addressService.Register(addressDto);

            Assert.False(registred);
        }

        [Theory]
        [InlineData(1, "felipe.bilhares", "random.username")]
        public async Task ShoulNotDeleteAddressWithDiferentUsername(int addressId, string usernameFromAdddres, string usernameFromApi)
        {
            var addressDto = GetAddressDto();
            var address = GetAddress();
            address.SetUser(new User(usernameFromAdddres));

            _addressRepositoryMock.Setup(x => x.FindById(addressId)).ReturnsAsync(address);

            var registred = await _addressService.Delete(usernameFromApi, addressId);

            Assert.False(registred);
        }

        [Theory]
        [InlineData(1, "felipe.bilhares", "felipe.bilhares")]
        public async Task ShoulDeleteAddress(int addressId, string usernameFromAdddres, string usernameFromApi)
        {
            var addressDto = GetAddressDto();
            var address = GetAddress();
            address.SetUser(new User(usernameFromAdddres));

            _addressRepositoryMock.Setup(x => x.FindById(addressId)).ReturnsAsync(address);
            _addressRepositoryMock.Setup(x => x.Delete(addressId)).ReturnsAsync(true);

            var registred = await _addressService.Delete(usernameFromApi, addressId);

            Assert.True(registred);
        }

        private AddressDto GetAddressDto()
        {
            return new AddressDto("79041-400", 183, "Campo Grande", "Avenia Afonso Pena", "Avenida", "MS", 1);
        }
        private Address GetAddress()
        {
            return new Address("79041-400", 183, "Campo Grande", "Avenia Afonso Pena", "Avenida", "MS", 1);
        }

        private GoogleMapsResultDto GetGoogleApiResultOk()
        {
            return new GoogleMapsResultDto("OK");
        }

        private GoogleMapsResultDto GetGoogleApiResultNotFound()
        {
            return new GoogleMapsResultDto("NOT_FOUND");
        }
    }
}
