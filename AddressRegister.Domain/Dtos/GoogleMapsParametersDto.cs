using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AddressRegister.Domain.Dtos
{
    public class GoogleMapsParametersDto
    {
        public string ApiUrl { get; set; }
        public string ApiPath { get; set; }
        public string InputType { get; set; }
        public string Fields { get; set; }
        public string ApiKey { get; set; }

        public GoogleMapsParametersDto()
        {
            ApiUrl = "https://maps.googleapis.com/maps/api";
            ApiPath = "/place/findplacefromtext/json";
            InputType = "textquery";
            Fields = "formatted_address";
            ApiKey = "";
        }
    }
}
