using intership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Data
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAllStores();
        Store GetStoreById(Guid id);
        void CreateStore(Store store);

        void UpdateStore(Store store);

        void DeleteStore(Store store);

        Store GetStoreMatchingCity(string keyword);

        Store GetStoreMatchingCountry(string keyword);

        void TrasferOwnership(Store store , string name);
        Store GetOledestStore();
    }
}
