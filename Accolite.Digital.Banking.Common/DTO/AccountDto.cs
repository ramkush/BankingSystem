using Accolite.Digital.Banking.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.DTO
{
    public class AccountDto
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public string CurrentBalance { get; set; }
        public DateTime DateOpened { get; set; }
        public bool AccountStatus { get; set; } = false;
        public long UserId { get; set; } 
    }
}
