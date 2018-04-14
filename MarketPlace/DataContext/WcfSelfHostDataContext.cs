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
