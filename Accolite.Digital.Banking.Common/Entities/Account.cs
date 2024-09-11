using Accolite.Digital.Banking.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.Entities
{
    public class Account
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime DateOpened { get; set; }
        public bool AccountStatus { get; set; }

        public long UserId { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime LastModDt { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }

    }
}
