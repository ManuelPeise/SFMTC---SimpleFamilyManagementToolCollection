using Data.ViewModels.CookingBook;
using Microsoft.AspNetCore.Mvc;

namespace Web.Core.ViewComponents
{
    public class RecipeCardViewComponent : ViewComponent
    {
        public RecipeCardViewComponent()
        {
    
        }

        public async Task<IViewComponentResult> InvokeAsync(RecipeCardViewModel model)
        {
            return await Task.FromResult(View(model));
        }
    }

}
