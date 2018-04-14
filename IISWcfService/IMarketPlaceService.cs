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
        IEnumerable<Product> GetProducts();

        [OperationContract]
        Product GetProduct(string id);

        [OperationContract]
        void CreateProduct(string id, string description, decimal price);

        [OperationContract]
        void CreatePurchase(DateTime date, string content);
    }
}
