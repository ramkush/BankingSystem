using Accolite.Digital.Banking.Common.DTO;
using Accolite.Digital.Banking.Common.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Accolite.Digital.Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public UserAccountController(IAccountService accountService) {
            _accountService = accountService;
        }  

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateAccounts([FromBody] AccountDto accountDto)
        {
            var responseDTO = _accountService.CreateAccount(accountDto);
            return Ok(responseDTO);
        }
        [HttpGet("GetAccountbyUser")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetAccountbyUser(long userId)
        {
            var user = _accountService.GetAllAccountsByUser(userId);
            return Ok(user);
        }
        [HttpDelete("DeleteAccount")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteAccount(string accountNumber,long userId)
        {
            var user = _accountService.DeleteAccount(accountNumber, userId);
            return Ok(user);
        }
        [HttpPost("WithdrawMoney")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult WithdrawMoney([FromBody] WithDrawRequestDto withDrawRequestDto)
        {
            var result =  _accountService.WithdrawMoney(withDrawRequestDto);
            return Ok(result); 
        }

        [HttpPost("DepositMoney")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DepositMoney([FromBody] DepositRequestDto depositRequestDto)
        {
            var result = _accountService.DepositMoney(depositRequestDto);
            return Ok(result);
        }

    }
}


