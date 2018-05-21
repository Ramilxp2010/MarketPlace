using System.Collections.Generic;

using MarketPlace.Model.Entities;

namespace MarketPlace.Client.DataContext
{
    public interface IDataContext
    {
        Product GetProduct(string id);
        void CreatePurchase(Purchase purchase);
    }
}
