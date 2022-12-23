using Data.Services.Enums;

namespace Data.Services.Models
{
    public class MenuSection
    {
        public int SortOrder { get; set; }
        public SectionEnum SectionId { get; set; }
        public string SectionIcon { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }

    public class MenuItem
    {
        public string ItemId { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public PageNameEnums page { get; set; }
        public string Path { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
}
