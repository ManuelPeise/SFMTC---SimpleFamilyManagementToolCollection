using Data.Identity;
using Data.Services.Enums;
using Data.Services.Interfaces;
using Data.ViewModels;

namespace Data.Services
{
    public class LayOutService : ILayoutService
    {
        private readonly IdentityContext _context;
        private IUserService _userService;

        public IUserService UserService
        {
            get => _userService ?? new UserService(_context);
            set => _userService = value;
        }

        public LayOutService(IdentityContext context)
        {
            _context = context;
            _userService = new UserService(context);
        }

        public async Task<NavigationViewModel> LoadLayoutViewModel()
        {
            var sections = Enum.GetNames(typeof(SectionEnum));
            var pageNames = Enum.GetNames(typeof(PageNameEnums));

            var navSections = (from s in sections
                               let value = (SectionEnum)Enum.Parse(typeof(SectionEnum), s)
                               select new NavigationSection
                               {
                                   SectionId = s,
                                   Title = s,
                                   IconClassName = GetIconClassName(value),
                                   IsCollapsed = false,
                                   MenuItems = GetNavItems(value)
                               }).ToList();

            return await Task.FromResult(new NavigationViewModel
            {
                NavigationSections = navSections
            });
        }

        #region private members

        private List<LinkViewModel> GetNavItems(SectionEnum value)
        {
            var type = NavigationTypeFactory.GetNavigationType(value);

            var navItemValues = NavigationTypeFactory.GetValues(type);

            var pages = (from item in navItemValues
                         select new LinkViewModel
                         {
                             DisplayName = item,
                             Disabled = false,
                             To = GetPath((PageNameEnums)Enum.Parse(type, item))
                         }).ToList();

            return pages;
        }

        private string GetPath(PageNameEnums page)
        {
            switch (page)
            {
                case PageNameEnums.Privacy:
                    return "/Privacy";
                default: return "/";
            }
        }

        private string GetIconClassName(SectionEnum section)
        {
            switch (section)
            {
                case SectionEnum.Pages:
                    return "fa-solid fa-file";
                //case SectionEnum.Profile:
                //    return "fa-solid fa-user";
                default: return "/";
            }
        }

        #endregion
    }
}
