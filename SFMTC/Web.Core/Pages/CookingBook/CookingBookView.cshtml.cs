using Data.ViewModels.CookingBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Data.Models.Cookingbook;
using Shared.Services.Interfaces;
using Web.Core.UIExtensions;

namespace Web.Core.Pages.CookingBook
{
    public class CookingBookViewModel : PageModel
    {
        private IHttpService _httpService;
        private IConfigService _configService;
        private readonly string _controller = "recipe/";

        [BindProperty]
        public List<RecipeCardViewModel> Recipes { get; set; } = new List<RecipeCardViewModel>();

        public CookingBookViewModel(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
        }

        public async Task<IActionResult> OnGet()
        {
            var models = await _httpService.Get<List<RecipeExportModel>>($"{_configService.ApiConfig.Value.BaseUrl}{_controller}GetRecipes", new List<KeyValuePair<string, string>>());

            Recipes = (from model in models
                       select model.ToViewModel()).ToList();
           
            return Page();
        }
    }
}
