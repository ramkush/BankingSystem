using Accolite.Digital.Banking.Common.DTO;
using Accolite.Digital.Banking.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Accolite.Digital.Banking.Common.Services.Interface;
using System.Net;
using Accolite.Digital.Banking.API.Attribute;

namespace Accolite.Digital.Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService iuserService) 
        { 
            _userService = iuserService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult SaveUser([FromBody] UserDto user)
        {
            var responseDTO =  _userService.CreateUser(user);
            return Ok(responseDTO);
        }
        [HttpGet("GetAllUsers")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetAlluser()
        {
            var user = _userService.GetUsers();
            return Ok(user);
        }
    }
}
