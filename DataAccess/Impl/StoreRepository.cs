using AssestmenNowOptics.Models;

namespace AssestmenNowOptics.DataAccess.Impl
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AssesmentDbContext _dbContext;

        public StoreRepository(AssesmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Store GetStore(int id)
        {
            return _dbContext.Stores.FirstOrDefault(s => s.StoreId == id);
        }

        public IEnumerable<Store> GetAll()
        {
            return _dbContext.Stores.ToList();
        }

        public void Add(Store store)
        {
            var existingStore = _dbContext.Stores.FirstOrDefault(s => s.StoreName == store.StoreName);
            if(existingStore == null)
            {
                _dbContext.Stores.Add(store);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Store store)
        {
            _dbContext.Stores.Update(store);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var store = _dbContext.Stores.FirstOrDefault(s => s.StoreId == id);
            if(store != null)
            {
                _dbContext.Stores.Remove(store);
                _dbContext.SaveChanges();
            }
        }
    }
}
