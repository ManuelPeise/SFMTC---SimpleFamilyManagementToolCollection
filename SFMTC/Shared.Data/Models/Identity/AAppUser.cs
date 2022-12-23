﻿using Microsoft.AspNetCore.Identity;
using Shared.Data.Enums.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Models.Identity
{
    public class AAppUser: IdentityUser
    {
        public UserRoleEnum Role { get; set; }
    }
}
