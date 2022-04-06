using intership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Data
{
    public class SQLStoreRepository : IStoreRepository
    {

        private readonly ProductContext _context;
        public SQLStoreRepository(ProductContext context )
        {
            _context = context;
        }

        public void CreateStore(Store store)
        {
            if (store != null)
            {
                _context.Stores.Add(store);
                _context.SaveChanges();
            }
            else
                throw new ArgumentNullException(nameof(store));
        }

        public void DeleteStore(Store store)
        {
            if (store != null)
            {
                _context.Stores.Remove(store);
                _context.SaveChanges();
            }
            else
                throw new ArgumentNullException(nameof(store));
        }

        public IEnumerable<Store> GetAllStores()
        {
            return _context.Stores.ToList();
        }

        public Store GetOledestStore()
        {
            return _context.Stores.ToList().Last();
        }

        public Store GetStoreById(Guid id)
        {
            return _context.Stores.FirstOrDefault(p => p.id == id);
        }

        public Store GetStoreMatchingCity(string keyword)
        {
            return _context.Stores.Find(keyword);
        }

        public Store GetStoreMatchingCountry(string keyword)
        {
            return _context.Stores.Find(keyword);
        }


        public void TrasferOwnership(Store store ,string name)
        {
            //nothing
        }

        public void UpdateStore(Store store)
        {
           //nothing
        }
    }
}
