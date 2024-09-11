using Accolite.Digital.Banking.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Accolite.Digital.Banking.Common.Services.Interface
{
    public interface IAccountService
    {
        ResponseDTO CreateAccount(AccountDto accountDto);
        ResponseDTO DeleteAccount(string accountNumber, long userId);
        ResponseDTO GetAllAccountsByUser(long userId);
        ResponseDTO WithdrawMoney(WithDrawRequestDto withDrawRequestDto);
        ResponseDTO DepositMoney(DepositRequestDto withDrawRequestDto);
    }
}
