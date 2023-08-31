using AssestmenNowOptics.Models;
using Microsoft.EntityFrameworkCore;

namespace AssestmenNowOptics.DataAccess.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly AssesmentDbContext _dbContext;
        public ProductRepository(AssesmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public void Add(Product product)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.ProductName == product.ProductName);
            if(existingProduct == null)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            if(product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
