using Business.CookingBook.Extensions;
using Data.Services.Interfaces;
using Shared.Data.Models.Cookingbook;

namespace Business.CookingBook
{
    public class RecipeHandler : IDisposable
    {
        private ICookingBookRepo _repo;
        private bool disposedValue;

        public RecipeHandler(ICookingBookRepo repo)
        {
            _repo = repo;
        }


        public async Task<IEnumerable<RecipeExportModel>> GetRecipes()
        {
            var entities = await _repo.GetRecipes();

            var recipes = from r in entities
                          select r.ToExportModel();

            return recipes;
        }

        public async Task<IEnumerable<RecipeExportModel>> GetFilteredRecipes(RecipeFilterModel filter)
        {
            var entities = await _repo.GetRecipes();

            if (filter.Name.Equals("all"))
            {
                return from recipe in entities
                       select recipe.ToExportModel();
            }

            if (string.IsNullOrWhiteSpace(filter.Category))
            {
                return from r in entities
                       where r.RecipeName.ToLower().StartsWith(filter.Name.ToLower())
                       select r.ToExportModel();
            }

            return from r in entities
                   where r.RecipeName.ToLower().StartsWith(filter.Name.ToLower()) &&
                   r.Category.ToLower().Equals(filter.Category.ToLower())
                   select r.ToExportModel();


        }

        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _repo.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
