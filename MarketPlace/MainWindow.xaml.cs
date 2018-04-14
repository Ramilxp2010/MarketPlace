using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MarketPlace.Client.ModelView;
using MarketPlace.Client.DataContext;
using System.Windows.Threading;

namespace MarketPlace
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new BasketViewModel(new DbDataContext(new DataManager(new ProductRepository(new SQLiteDatabase()), new PurchaseRepository(new SQLiteDatabase()))));
            DataContext = new BasketViewModel(new WcfDataContext());
            //DataContext = new BasketViewModel(new WcfSelfHostDataContext());
        }
    }
}
