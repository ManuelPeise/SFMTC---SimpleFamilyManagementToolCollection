using Datta.AppDataAccessLayer.Entities.CookingBook;

namespace Data.Services.Interfaces
{
    public interface ICookingBookRepo: IDisposable
    {
        Task<List<Recipe>> GetRecipes();
    }
}
