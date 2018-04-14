using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

using MarketPlace.Model.Entities;
using MarketPlace.Client.MarketPlaceService;

namespace MarketPlace.Client.DataContext
{
    public class WcfDataContext : IDataContext
    {
        private IMarketPlaceService client;
        public WcfDataContext()
        {
            client = new MarketPlaceServiceClient("BasicHttpBinding_IMarketPlaceService");
        }

        public Product GetProduct(string id)
        {
            return client.GetProduct(id);
        }
        public void CreatePurchase(Purchase purchase)
        {
            client.CreatePurchase(purchase);
        }
    }
}
