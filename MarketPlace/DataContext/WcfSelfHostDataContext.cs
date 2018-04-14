using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

using MarketPlace.Model.Entities;
using MarketPlace.Client.MarketPlaceSelfHostService;

namespace MarketPlace.Client.DataContext
{
    public class WcfSelfHostDataContext : IDataContext
    {
        private IMarketPlaceService client;

        public WcfSelfHostDataContext()
        {
            client = new MarketPlaceServiceClient("BasicHttpBinding_IMarketPlaceService1");
        }

        public IEnumerable<Product> GetProducts()
        {
            return client.GetProducts();
        }
        public Product GetProduct(string id)
        {
            return client.GetProduct(id);
        }
        public void CreateProduct(string id, string description, decimal price)
        {
            client.CreateProduct(id, description, price);
        }

        public void CreatePurchase(DateTime date, string content)
        {
            client.CreatePurchase(date, content);
        }
    }
}
