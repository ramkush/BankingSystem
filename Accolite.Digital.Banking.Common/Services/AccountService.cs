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
    public class AccountService : IAccountService
    {
        private readonly IDataService _dummyDataService;
        private readonly IMapper _mapper;
        public AccountService(IDataService dummyDataService,IMapper mapper) {
            _dummyDataService = dummyDataService;
            _mapper = mapper;
        }
        public ResponseDTO CreateAccount(AccountDto accountDto)
        {
            _dummyDataService.SaveAccount(_mapper.Map<Account>(accountDto));
            return new ResponseDTO() { IsSuccess = true ,Message="Success",Result=null};
        }

        public ResponseDTO GetAllAccountsByUser(long userId)
        {
            List<Account> accountList  = _dummyDataService.GetAllAccountsByUser(userId);
            if (accountList.Count == 0)
            {
                return new ResponseDTO() { IsSuccess = false, Message = "Not Found", Result = null };

            }
            else
            {
                return new ResponseDTO() { IsSuccess = true, Message = "Success", Result = accountList };
            }
        }
        public ResponseDTO DeleteAccount(string  accountNumber,long userId)
        {
            var account =  _dummyDataService.GetAllAccountsByUser(userId).SingleOrDefault(ac=> ac.AccountNumber == accountNumber);
            if (account == null)
            {
                return new ResponseDTO() { IsSuccess=false ,Message="Not Found", Result=null};

            }
            else
            {
                 account.AccountStatus = false;
                return new ResponseDTO() { IsSuccess = true, Message = "Delete Success", Result = null };

            }
        }
        public ResponseDTO WithdrawMoney(WithDrawRequestDto withdrawRequestDto)
        {
            var account = _dummyDataService.GetAllAccountsByUser(withdrawRequestDto.userid).SingleOrDefault(ac => ac.AccountNumber == withdrawRequestDto.AccountNumber);
            if (account != null)
            {
                double eligibleWithdrawAmount = (account.CurrentBalance) * .9;
                if(withdrawRequestDto.Amount > eligibleWithdrawAmount)
                {
                    return new ResponseDTO() { IsSuccess = false, Message = "WithDraw Amount greater than 90% account Balance", Result = null };
                }
                else
                {
                    account.CurrentBalance = account.CurrentBalance - withdrawRequestDto.Amount;
                    return new ResponseDTO() { IsSuccess = true, Message = "WithDraw success", Result = account };
                }
            }
            else
            {
                return new ResponseDTO() { IsSuccess = false, Message = "Not Found", Result = null };
            }
        }
        public ResponseDTO DepositMoney(DepositRequestDto depositRequestDto)
        {
            var account = _dummyDataService.GetAllAccountsByUser(depositRequestDto.userid).SingleOrDefault(ac => ac.AccountNumber == depositRequestDto.AccountNumber);
            if (account != null)
            {
                if (depositRequestDto.Amount > 10000)
                {
                    return new ResponseDTO() { IsSuccess = false, Message = "A user cannot deposit more than $10,000 in a single transaction", Result = null };
                }
                else
                {
                    account.CurrentBalance = account.CurrentBalance + depositRequestDto.Amount;
                    return new ResponseDTO() { IsSuccess = true, Message = "Deposit success", Result = account };
                }
            }
            else
            {
                return new ResponseDTO() { IsSuccess = false, Message = "Not Found", Result = null };
            }
        }
    }
}
