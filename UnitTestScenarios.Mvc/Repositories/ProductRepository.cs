using Microsoft.EntityFrameworkCore;
using UnitTestScenarios.Mvc.Entity;

namespace UnitTestScenarios.Mvc.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
            _products = _context.Set<Product>();

        }
        public void Add(Product entity)
        {
            _products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _products.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _products.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Product> GetAsync(long id)
        {
            return await _products.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public void Update(Product entity)
        {
            _products.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
