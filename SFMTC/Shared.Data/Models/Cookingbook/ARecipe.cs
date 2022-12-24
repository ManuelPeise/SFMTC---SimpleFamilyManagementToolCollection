using System.ComponentModel.DataAnnotations;

namespace Shared.Data.Models.Cookingbook
{
    public class ARecipe
    {
        [Key]
        public Guid RecipeId { get; set; }
        [MaxLength(50)]
        public string RecipeName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string ShortDescription { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } 
        public string Category { get; set; } = string.Empty;


    }
}
