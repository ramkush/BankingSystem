using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.Entities
{
    public class User
    {

        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; }
        public string phone { get; set; } = null!;
        public string Address { get; set; }  = null!;
        public DateTime? CreatedDt { get; set; }
        public DateTime? LastModDt { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
