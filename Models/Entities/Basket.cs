using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace MarketPlace.Model.Entities
{
    public class Basket : INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "Products")]
        private List<Product> products = new List<Product>();

        [JsonIgnore]
        public IEnumerable<Product> Products
        {
            get { return products; }
        }
        
        [JsonProperty(PropertyName = "TotalPrice")]
        public decimal TotalPrice
        {
            get { return products.Sum(e => e.Price); }
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                return;

            if (products.FirstOrDefault(x => x.Id == product.Id) == null)
            {
                products.Add(product);
                OnPropertyChanged("Products");
                OnPropertyChanged("TotalPrice");
            }
        }
        public void RemoveProduct(Product product)
        {
            products.RemoveAll(p => p.Id == product.Id);
            OnPropertyChanged("Products");
            OnPropertyChanged("TotalPrice");
        }
        public void ClearBasket()
        {
            products.Clear();
            OnPropertyChanged("Products");
            OnPropertyChanged("TotalPrice");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
