using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarketPlace.Model.Interface;

namespace MarketPlace.Model
{
    public class DataManager
    {
        private IProductRepository productRepository;
        private IPurchaseRepository purchaseRepository;

        public DataManager(IProductRepository productRepository, IPurchaseRepository purchaseRepository)
        {
            this.productRepository = productRepository;
            this.purchaseRepository = purchaseRepository;
        }

        public IProductRepository Products { get { return productRepository; } }
        public IPurchaseRepository Purchases { get { return purchaseRepository; } }
    }
}
