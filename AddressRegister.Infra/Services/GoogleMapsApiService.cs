using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressRegister.Infra.Services
{
    public class GoogleMapsApiService : IGoogleMapsApiService
    {
        public async Task<GoogleMapsResultDto> FindAddress(AddressDto address)
        {
            var parameters = new GoogleMapsParametersDto();

            var restClient = new RestClient(parameters.ApiUrl);
            var request = new RestRequest(parameters.ApiPath, Method.GET);

            request.AddParameter("inputtype", parameters.InputType, ParameterType.QueryString);
            request.AddParameter("fields", parameters.Fields, ParameterType.QueryString);
            request.AddParameter("key", parameters.ApiKey, ParameterType.QueryString);

            request.AddParameter("input", GetFormatedAddress(address), ParameterType.QueryString);

            var response = await restClient.ExecuteAsync(request);

            var googleMapResultDto = JsonConvert.DeserializeObject<GoogleMapsResultDto>(response.Content);

            return googleMapResultDto;

        }

        private string GetFormatedAddress(AddressDto address)
        {
            return $"{address.District}, {address.City} - {address.State}, {address.ZipCode}, Brasil";
        }
    }
}
