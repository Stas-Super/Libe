using AutoMapper;
using Libe.AccountMicroservice.Business.Dtos;
using Libe.AccountMicroservice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Business.Mapper
{
    public class AccountMicroserviceMapProfile : Profile
    {
        public AccountMicroserviceMapProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.RefreshToken, opt => opt.Ignore())
                .ForMember(u => u.RefreshToken, opt => opt.Ignore())
                .ForMember(u => u.User, opt => opt.Ignore());
        }
    }
}
