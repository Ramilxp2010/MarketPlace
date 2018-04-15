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
using MarketPlace.Model;

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

            // Использование сервиса. Pаботает с IIS
            DataContext = new BasketViewModel(new WcfDataContext());

            // Использование сервиса. Работает с отдельным хостом
            //DataContext = new BasketViewModel(new WcfSelfHostDataContext());

            /*
             * Для прямого подключения приложения к БД. 
             * 
            string dbPathName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbFileName = "database.sqlite";
            string databasePath = Path.Combine(dbPathName, dbFileName);

            //Реализация с использованием Sqlite-net-pcl
            DataManager dataManager = new DataManager(new ProductRepositoryBySqliteNet(databasePath), new PurchaseRepositoryBySqliteNet(databasePath));
            DataContext = new BasketViewModel(new DbDataContext(dataManager));*/

            //Реализация с использованием System.Data.SQLite
            /*SQLiteDatabase sqliteDatabase = new SQLiteDatabase(dbPathName, dbFileName);
            IProductRepository productRepository = new ProductRepository(sqliteDatabase);
            IPurchaseRepository purchaseRepository = new PurchaseRepository(sqliteDatabase);
            this.dataManager = new DataManager(productRepository, purchaseRepository);
            DataContext = new BasketViewModel(new DbDataContext(dataManager));*/
        }
    }
}
