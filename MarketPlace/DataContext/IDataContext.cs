using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

using MarketPlace.Model.Entities;

namespace MarketPlace.Client.DataContext
{
    public interface IDataContext
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string id);
        void CreateProduct(string id, string description, decimal price);
        void CreatePurchase(DateTime date, string content);
    }
}
