using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Data;
using WebSiteMachines.FiltersModel;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;

namespace WebSiteMachines.Repositories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategories(CategoryFilter filter)
        {
            if (filter == null)
            {
                return await _context.Category.ToListAsync();
            }
            var result = _context.Category.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(x => x.Name == filter.Name);
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
