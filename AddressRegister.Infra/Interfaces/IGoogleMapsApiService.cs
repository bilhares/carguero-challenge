using AddressRegister.Domain.Dtos;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Interfaces
{
    public interface IGoogleMapsApiService
    {
        Task<GoogleMapsResultDto> FindAddress(AddressDto address);
    }
}
