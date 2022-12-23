using Data.Services.Enums;
using Data.Services.Models;

namespace Data.Services
{
    public static class NavigationTypeFactory
    {
        internal static MenuSection GetSection(SectionEnum section)
        {
            switch (section)
            {
                case SectionEnum.CookingBook:
                    return new MenuSection
                    {
                        SortOrder = 0,
                        SectionId = section,
                        DisplayName = GetDisplayName(section),
                        SectionIcon = GetSectionIcon(section),
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                 ItemId = "CookingBookView",
                                 SortOrder = 0,
                                 DisplayName = "Ansehen",
                                 Path = "/CookingBook/CookingBookView",
                                 page = PageNameEnums.CookingBookView
                            },
                             new MenuItem
                            {
                                 ItemId = "CookingBookAdd",
                                 SortOrder = 1,
                                 DisplayName = "Hinzufügen",
                                 Path = "/CookingBook/CookingBookAdd",
                                 page = PageNameEnums.CookingBookAdd
                            }
                        }
                    };
                default: return null;
            }
        }

        private static string GetSectionIcon(SectionEnum section)
        {
            switch (section)
            {
                case SectionEnum.CookingBook:
                    return "fa-solid fa-utensils";
                default: return string.Empty;
            }
        }

        private static string GetDisplayName(SectionEnum section)
        {
            switch (section)
            {
                case SectionEnum.CookingBook:
                    return "Kochbuch";
                default: return string.Empty;
            }
        }
    }
}
