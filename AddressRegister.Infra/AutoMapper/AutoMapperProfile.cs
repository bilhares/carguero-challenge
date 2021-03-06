using AddressRegister.Domain.Dtos;
using AddressRegister.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressRegister.Infra.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        protected void Configure()
        {
            CreateMap<User, UserDto>();          
        }
    }
}
