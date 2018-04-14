using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace MarketPlace.Model.Entities
{
    public class Basket : INotifyPropertyChanged
    {
        [XmlElement("Product")]
        public List<Product> products = new List<Product>();
        public IEnumerable<Product> Products
        {
            get { return products; }
        }
        public decimal TotalPrice
        {
            get { return products.Sum(e => e.Price); }
            set { }
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
