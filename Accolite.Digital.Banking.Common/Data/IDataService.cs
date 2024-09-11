using Accolite.Digital.Banking.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.Data
{
    public interface IDataService
    {
        bool SaveUser(User user);
        bool SaveAccount(Account account);
        bool DeleteAccount(Account account);
        List<Account> GetAllAccountsByUser(long Id);
        List<User> GetAllUser();
    }
}
