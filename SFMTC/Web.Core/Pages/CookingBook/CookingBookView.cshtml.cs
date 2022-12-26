using Data.ViewModels.CookingBook;
using Microsoft.AspNetCore.Components.Web;
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
        [BindProperty]
        public RecipeFilterViewModel Filter { get; set; } = new RecipeFilterViewModel();

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

        public async Task<IActionResult> OnPostSubmitFilter()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if(Filter.Name != null && Filter.Name.Length > 0)
            {
                parameters.Add(new KeyValuePair<string, string>("name", Filter.Name));
            }
            else
            {
                parameters.Add(new KeyValuePair<string, string>("name", "all"));
            }

            if(Filter.Category != null && Filter.Category.Length > 0)
            {
                parameters.Add(new KeyValuePair<string, string>("category", Filter.Category));
            }
            
            var filteredRecipes = await _httpService.Get<List<RecipeExportModel>>($"{_configService.ApiConfig.Value.BaseUrl}{_controller}GetFilteredRecipes", parameters);

            Recipes = (from model in filteredRecipes
                       select model.ToViewModel()).ToList();
            return Page();
        }
    }
}
