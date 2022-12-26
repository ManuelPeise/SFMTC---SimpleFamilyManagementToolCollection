using Business.CookingBook;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Data.Models.Cookingbook;

namespace Service.CookingBook.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RecipeController: ControllerBase
    {
        private ICookingBookRepo _repo;

        public RecipeController(ICookingBookRepo repo)
        {
            _repo = repo;
        }

        // URI: https://localhost:44309/api/recipe/GetRecipes
        [HttpGet]
        public async Task<IEnumerable<RecipeExportModel>> GetRecipes()
        {
            using(var handler = new RecipeHandler(_repo))
            {
                return await handler.GetRecipes();
            }
        }

        // URI: https://localhost:44309/api/recipe/GetFilteredRecipes?name=test&category=hallo
        [HttpGet]
        public async Task<IEnumerable<RecipeExportModel>> GetFilteredRecipes([FromQuery]RecipeFilterModel filter)
        {
            using (var handler = new RecipeHandler(_repo))
            {
                return await handler.GetFilteredRecipes(filter);
            }
        }
    }
}
