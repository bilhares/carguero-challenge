using System;
using System.Collections.Generic;
using System.Text;

namespace AddressRegister.Domain.Dtos
{
    public class GoogleMapsResultDto
    {
        public string status { get; set; }

        public GoogleMapsResultDto()
        {
        }

        public GoogleMapsResultDto(string status)
        {
            this.status = status;
        }
    }
}
