using Data.Identity;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class UserService: IUserService
    {
        private readonly IdentityContext _context;
        
        public UserService(IdentityContext context)
        {
            _context = context;
        }
    }
}
