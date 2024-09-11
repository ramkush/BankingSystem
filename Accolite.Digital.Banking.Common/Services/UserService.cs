using Accolite.Digital.Banking.Common.Data;
using Accolite.Digital.Banking.Common.DTO;
using Accolite.Digital.Banking.Common.Entities;
using Accolite.Digital.Banking.Common.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.Services
{
    public class UserService : IUserService
    {
        private IDataService _DummyDataService;
        IMapper _mapper;
        public UserService(IDataService dummyDataService,IMapper mapper) 
        {
            _DummyDataService = dummyDataService;
            _mapper = mapper;
        }    
        public ResponseDTO CreateUser(UserDto userDto)
        {          
            _DummyDataService.SaveUser(_mapper.Map<User>(userDto));
            return new ResponseDTO(){ IsSuccess = true ,Message="",Result = null}; 
        }

        public List<UserDto> GetUsers()
        {
            var user = _DummyDataService.GetAllUser();

            return _mapper.Map<List<UserDto>>(user);
        }
    }
}
