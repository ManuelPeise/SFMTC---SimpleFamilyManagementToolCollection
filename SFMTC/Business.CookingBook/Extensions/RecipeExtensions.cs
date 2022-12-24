using Business.CookingBook.ExportModels;
using Datta.AppDataAccessLayer.Entities.CookingBook;

namespace Business.CookingBook.Extensions
{
    internal static class RecipeExtensions
    {
        internal static RecipeExportModel ToExportModel(this Recipe recipe)
        {
            return new RecipeExportModel
            {
                RecipeId = recipe.RecipeId,
                RecipeName = recipe.RecipeName,
                Category = recipe.Category,
                Description = recipe.Description,
                Image = recipe.Image,
                ShortDescription = recipe.ShortDescription,
            };
        }
    }
}
