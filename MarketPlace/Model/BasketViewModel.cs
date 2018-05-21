using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using MarketPlace.Model.Entities;
using MarketPlace.Client.Command;
using MarketPlace.Client.DataContext;

namespace MarketPlace.Client.ModelView
{
    public class BasketViewModel : INotifyPropertyChanged
    {
        public readonly Basket Basket;
        public readonly IDataContext dataContext;

        private string productCode;
        public string ProductCode
        {
            get { return productCode; }
            set
            {
                productCode = value;
                OnPropertyChanged("ProductCode");
            }
        }

        public ObservableCollection<Product> Products
        {
            get { return new ObservableCollection<Product>(Basket.Products); }
        }
        public decimal TotalPrice
        {
            get { return Basket.TotalPrice; }
        }

        private ICommand addCommand;
        public ICommand AddProduct
        {
            get
            {
                if (addCommand != null) 
                    return addCommand;
                addCommand = new AddCommand(this);
                return addCommand;
            }
        }

        private ICommand buyCommand;
        public ICommand Buy
        {
            get
            {
                if (buyCommand != null) 
                    return buyCommand;
                buyCommand = new BuyCommand(this);
                return buyCommand;
            }
        }

        public BasketViewModel(IDataContext dataContext)
        {
            this.dataContext = dataContext;
            Basket = new Basket();
            Basket.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
