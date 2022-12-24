using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Data.Models.Cookingbook;
using Shared.Services.Interfaces;
using System.Collections.Generic;

namespace Web.Core.Pages.CookingBook
{
    public class CookingBookViewModel : PageModel
    {
        private IHttpService _httpService;
        private IConfigService _configService;
        private readonly string _controller = "recipe/";

        [BindProperty]
        public List<RecipeExportModel> Recipes { get; set; } = new List<RecipeExportModel>();

        public CookingBookViewModel(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
        }

        public async Task<IActionResult> OnGet()
        {
            Recipes = await _httpService.Get<List<RecipeExportModel>>($"{_configService.ApiConfig.Value.BaseUrl}{_controller}GetRecipes", new List<KeyValuePair<string, string>>());
            
            return Page();
        }
    }
}
