using Accolite.Digital.Banking.Common.Constants;
using Accolite.Digital.Banking.Common.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.Data
{
    public class DummyDataService : IDataService
    {

        public List<User> userList = new List<User>() { new User() {Id=1, Name="Sam",Email="Sam@gmail.com",UserName="sam001",Password="Test@123",Address="India",CreatedBy=100,CreatedDt=DateTime.Now} ,
         new User() { Id=2,Name="Tim",Email="Tim@gmail.com",UserName="Tim001",Password="Test@123",Address="India",CreatedBy=100,CreatedDt=DateTime.Now},
         new User() {Id=3, Name="Sneha",Email="Sneha@gmail.com",UserName="Sneha001",Password="Test@123",Address="India",CreatedBy=100,CreatedDt=DateTime.Now}};

   

        public static List<Account> accountList = new List<Account>() { new Account() { UserId = 1, AccountNumber = "1000567", AccountStatus = true, AccountType = Constants.AccountType.Saving, CurrentBalance = 110000.00, DateOpened = DateTime.Now, Id = 1, CreatedBy = 100, CreatedDt = DateTime.Now },
        new Account{ Id=2,UserId=1,AccountNumber="1000567",AccountStatus=true,AccountType=Constants.AccountType.Saving,CurrentBalance=120000.00,DateOpened=DateTime.Now,CreatedBy=100,CreatedDt=DateTime.Now},
        new Account() {Id = 3, UserId = 2, AccountNumber = "1109945", AccountStatus = true, AccountType = Constants.AccountType.Saving, CurrentBalance = 140000.00, DateOpened = DateTime.Now, CreatedBy = 100, CreatedDt = DateTime.Now },
        new Account{ Id=4, UserId=2,AccountNumber="12450567",AccountStatus=true,AccountType=Constants.AccountType.Saving,CurrentBalance=160000.00,DateOpened=DateTime.Now,CreatedBy=100,CreatedDt=DateTime.Now},};
       
        public bool DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAllAccountsByUser(long Id)
        {
            return accountList.Where(account => account.UserId == Id && account.AccountStatus == true).ToList();
        }

        public bool SaveAccount(Account account)
        {
           accountList.Add(account);
            return true;
        }

        public bool SaveUser(User user)
        {
            userList.Add(user);
            return true;
        }
        public List<User> GetAllUser()
        {
            return userList;
        }
    }
}
