using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MarketPlace.Model.Entities
{
    public class Product: INotifyPropertyChanged
    {
        private string id;
        private string description;
        private decimal price;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ProductCode");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
      
        public Product(){}
        public Product(string id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
