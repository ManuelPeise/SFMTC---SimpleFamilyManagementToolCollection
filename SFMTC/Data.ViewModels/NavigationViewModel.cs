namespace Data.ViewModels
{
    public class NavigationViewModel
    {
        public List<NavigationSection> NavigationSections { get; set; } = new List<NavigationSection>();
    }

    public class NavigationSection
    {
        public string SectionId { get; set; } = string.Empty;
        public string IconClassName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool IsCollapsed { get; set; }
        public List<LinkViewModel> MenuItems { get; set; } = new List<LinkViewModel>();

    }
}
