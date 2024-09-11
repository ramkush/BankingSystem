using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.DTO
{
    public class DepositRequestDto
    {
        public long userid { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
    }
}
