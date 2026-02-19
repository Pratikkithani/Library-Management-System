using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly LibraryDbContext _libraryDbContext;
        public CategoryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _libraryDbContext.Categories.AddAsync(category);
            await _libraryDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category is not null)
            {
                _libraryDbContext.Categories.Remove(category);
                return await _libraryDbContext.SaveChangesAsync() > 0;

            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _libraryDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _libraryDbContext.Categories.FirstOrDefaultAsync(b => b.CategoryId == id);

        }

        public async Task<bool> UpdateCategoryAsync(int categoryId, Category category)
        {
            var result = await GetCategoryByIdAsync(categoryId);
            if (result is not null)
            {
                _libraryDbContext.Categories.Update(category);
                return await _libraryDbContext.SaveChangesAsync() > 0;

            }
            return false;
        }
    }
}
