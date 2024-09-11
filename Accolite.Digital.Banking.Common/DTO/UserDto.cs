﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Digital.Banking.Common.DTO
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; }
        public string phone { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
