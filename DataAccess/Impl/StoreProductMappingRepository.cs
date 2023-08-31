using AssestmenNowOptics.Models;
using Microsoft.EntityFrameworkCore;

namespace AssestmenNowOptics.DataAccess.Impl
{
    public class StoreProductMappingRepository : IStoreProductMappingRepository
    {
        private readonly AssesmentDbContext _dbContext;

        public StoreProductMappingRepository(AssesmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StoreProductMapping GetStoreProductMapping(int id)
        {
            return _dbContext.ProductMappings.FirstOrDefault(p => p.MappingId == id);
        }

        public IEnumerable<StoreProductMapping> GetAll()
        {
            return _dbContext.ProductMappings.ToList();
        }

        public void Add(StoreProductMapping storeProductMapping)
        {
            var existingMapping = _dbContext.ProductMappings.FirstOrDefault(p => p.ProductId == storeProductMapping.ProductId && p.StoreId == storeProductMapping.StoreId);
            if(existingMapping == null)
            {
                _dbContext.ProductMappings.Add(storeProductMapping);
                _dbContext.SaveChanges();
            }
        }

        public void Update(StoreProductMapping storeProductMapping)
        {
            _dbContext.ProductMappings.Update(storeProductMapping);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var mapping = _dbContext.ProductMappings.FirstOrDefault(p => p.MappingId == id);
            if(mapping != null)
            {
                _dbContext.ProductMappings.Remove(mapping);
                _dbContext.SaveChanges();
            }
        }
    }
}
