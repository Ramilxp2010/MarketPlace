using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarketPlace.Model.Entities;

namespace MarketPlace.Model.Interface
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> Purchases();
        Purchase GetPurchase(int id);
        void CreatePurchase(Purchase purchase);
    }
}
