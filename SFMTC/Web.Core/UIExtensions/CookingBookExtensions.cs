using Data.ViewModels.CookingBook;
using Shared.Data.Models.Cookingbook;

namespace Web.Core.UIExtensions
{
    public static class CookingBookExtensions
    {
        public static RecipeCardViewModel ToViewModel(this RecipeExportModel model)
        {
            return new RecipeCardViewModel
            {
                RecipeId = model.RecipeId,
                RecipeName = model.RecipeName,
                Category = model.Category,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                Image = model.Image,
            };
        }

        public static RecipeFilterViewModel ToViewModel(this RecipeFilterModel model) 
        {
            return new RecipeFilterViewModel
            {
                Category = model.Category,
                Name = model.Name,
            };
        }
    }
}
