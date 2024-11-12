using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Data;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using WebSiteMachines.ViewModels.Category;

namespace WebSiteMachines.Repositories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategories(CategorySearchViewModel? categorySearchViewModel = null)
        {
            if (categorySearchViewModel == null)
            {
                return await _context.Category.ToListAsync();
            }
            var result = _context.Category.AsQueryable();

            if (!string.IsNullOrEmpty(categorySearchViewModel.Name))
            {
                result = result.Where(x => x.Name == categorySearchViewModel.Name);
            }

            return await result.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return _context.Category.FirstOrDefault(i => i.Id == id);
        }
        public bool Add(Category category)
        {
            _context.Category.Add(category);
            return Save();
        }

        public bool Delete(Category category)
        {
            _context.Category.Remove(category);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Category category)
        {
            _context.Category.Update(category);
            return Save();
        }
    }
}
