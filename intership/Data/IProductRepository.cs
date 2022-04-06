using intership.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Data
{
   
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
        IEnumerable<Product> GetProductMatching(string keyword);
        Product GetRecentProduct();
        Product GetOledestProduct();


    }
}
