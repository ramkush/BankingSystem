using Accolite.Digital.Banking.Common.DTO;
using Accolite.Digital.Banking.Common.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<UserDto, User>()
                 .ForMember(dest => dest.LastModDt, m => m.MapFrom(src => DateTime.Now))
                 .ForMember(dest => dest.CreatedDt, m => m.MapFrom(src => DateTime.Now));
            CreateMap<User, UserDto>();
        }
    }
}
