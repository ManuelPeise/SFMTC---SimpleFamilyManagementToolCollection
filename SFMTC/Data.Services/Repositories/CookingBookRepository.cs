using Data.Services.Interfaces;
using Datta.AppDataAccessLayer;
using Datta.AppDataAccessLayer.Entities.CookingBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Repositories
{
    public class CookingBookRepository : ICookingBookRepo
    {
        private bool disposedValue;

        private AppDataContext _context;

        public CookingBookRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            try
            {
                return await Task.FromResult(_context.Recipes.ToList());

            }catch(Exception ex)
            {
                return new List<Recipe>();
            }
        }


        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
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
