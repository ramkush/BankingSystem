using Accolite.Digital.Banking.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.Services.Interface
{
    public interface IUserService
    {
        ResponseDTO CreateUser(UserDto userDto);
        List<UserDto> GetUsers();
    }
}
