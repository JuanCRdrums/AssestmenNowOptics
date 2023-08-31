using AssestmenNowOptics.Models;

namespace AssestmenNowOptics.DataAccess
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
