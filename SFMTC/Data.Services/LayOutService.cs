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

            var navSections = (from s in sections
                               let model = NavigationTypeFactory.GetSection((SectionEnum)Enum.Parse(typeof(SectionEnum), s))
                               let value = (SectionEnum)Enum.Parse(typeof(SectionEnum), s)
                               select new NavigationSection
                               {
                                   SectionId = model.SectionId.ToString(),
                                   Title = model.DisplayName,
                                   IconClassName = model.SectionIcon,
                                   IsCollapsed = false,
                                   MenuItems = (from item in model.MenuItems
                                                select new LinkViewModel
                                                {
                                                    ItemId = item.ItemId,
                                                    Disabled = false,
                                                    DisplayName = item.DisplayName,
                                                    To = item.Path
                                                }).ToList()
                               }).ToList();

            return await Task.FromResult(new NavigationViewModel
            {
                NavigationSections = navSections
            });
        }

    }
}
