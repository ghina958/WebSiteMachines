using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Data;
using WebSiteMachines.FiltersModel;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;

namespace WebSiteMachines.Repositories
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll(ProductFilter filter )
        {
            if (filter == null)
            {
                return await _context.Product.Include(c => c.Category).ToListAsync();
            }

            var result = _context.Product.Include(c => c.Category).AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(x => x.Name == filter.Name);
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                result = result.Where(x => x.Description == filter.Description);
            }

            if (filter.CategoryId != 0)
            {
                result = result.Where(x => x.CategoryId == filter.CategoryId);
            }

            return await result.ToListAsync();
        }

        public async Task<Product?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Product.Include(i => i.Category).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Product.Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Add(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool Delete(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
