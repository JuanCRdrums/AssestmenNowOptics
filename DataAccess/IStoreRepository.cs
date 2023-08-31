using AssestmenNowOptics.Models;

namespace AssestmenNowOptics.DataAccess
{
    public interface IStoreRepository
    {
        Store GetStore(int id);
        IEnumerable<Store> GetAll();
        void Add(Store store);
        void Update(Store store);
        void Delete(int id);
    }
}
