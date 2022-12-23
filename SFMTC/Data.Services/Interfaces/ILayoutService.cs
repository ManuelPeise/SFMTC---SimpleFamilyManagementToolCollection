using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ILayoutService
    {
        public IUserService UserService { get; set; }

        Task<NavigationViewModel> LoadLayoutViewModel();
    }
}
