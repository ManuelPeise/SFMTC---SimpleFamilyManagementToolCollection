using Business.CookingBook.ExportModels;
using Business.CookingBook.Extensions;
using Business.CookingBook.Interfaces;
using Business.CookingBook.Models;
using Data.Services.Interfaces;

namespace Business.CookingBook
{
    public class RecipeHandler: IDisposable
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

            var recipes = from r in entities
                          where r.RecipeName.ToLower().StartsWith(filter.Name) &&
                          r.Category.ToLower().Equals(filter.Category.ToLower())
                          select r.ToExportModel();

            return recipes;
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
