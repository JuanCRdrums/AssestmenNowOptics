using AssestmenNowOptics.Models;

namespace AssestmenNowOptics.DataAccess
{
    public interface IStoreProductMappingRepository
    {
        StoreProductMapping GetStoreProductMapping(int id);
        IEnumerable<StoreProductMapping> GetAll();
        void Add(StoreProductMapping storeProductMapping);
        void Update(StoreProductMapping storeProductMapping);
        void Delete(int id);
    }
}
