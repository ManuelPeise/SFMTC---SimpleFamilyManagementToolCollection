using Data.Services.Enums;

namespace Data.Services
{
    public static class NavigationTypeFactory
    {
        public static Type GetNavigationType(SectionEnum section)
        {
            switch (section)
            {
                case SectionEnum.Pages:
                    return typeof(PageNameEnums);
                //case SectionEnum.Profile:
                //    return typeof(ProfilePageEnum);
                default: return null;
            }
        }

        internal static List<string> GetValues(Type type)
        {
            return Enum.GetNames(type).ToList();
        }
    }
}
