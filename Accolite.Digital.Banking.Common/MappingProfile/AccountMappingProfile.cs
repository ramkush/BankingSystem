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
    public class AccountMappingProfile :Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<AccountDto, Account>()
                 .ForMember(dest => dest.LastModDt, m => m.MapFrom(src => DateTime.Now))
                 .ForMember(dest => dest.CreatedDt, m => m.MapFrom(src => DateTime.Now));
            CreateMap<Account, AccountDto>();
        }
    }
}
