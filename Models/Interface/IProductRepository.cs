using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
