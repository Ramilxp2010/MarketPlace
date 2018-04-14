using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using MarketPlace.Model.Entities;

namespace MarketPlace.Service.IISWcfService
{
    [ServiceContract]
    public interface IMarketPlaceService
    {
        [OperationContract]
        Product GetProduct(string id);

        [OperationContract]
        void CreatePurchase(Purchase purchase);
    }
}
