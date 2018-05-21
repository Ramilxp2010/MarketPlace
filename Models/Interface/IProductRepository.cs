using System.Collections.Generic;
using MarketPlace.Model.Entities;

namespace MarketPlace.Model.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string id);
        void CreateProduct(Product product);
    }
}
