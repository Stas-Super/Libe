using AutoMapper;
using Libe.Domain.Core.Entities;
using Libe.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Infrastructure.Bussines.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RegistrationRequestModel, User>();
        }
    }
}
