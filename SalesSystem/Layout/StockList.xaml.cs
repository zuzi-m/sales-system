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

using SalesSystem.Models;
using SalesSystem.Services;

namespace SalesSystem.Layout
{
    /// <summary>
    /// Interaction logic for StockList.xaml
    /// </summary>
    public partial class StockList : Page
    {
        private StockManager _stockManager;
        public Customer CurrentCustomer { get; set; }

        // command for buying items - handles the update and checks if buy is possible
        public static RoutedCommand BuyCommand = new RoutedCommand();
        public StockList()
        {
            // initialize the stock manager
            _stockManager = new StockManager();

            // set the data context to this class
            CurrentCustomer = _stockManager.Customer;
            this.DataContext = this;

            // initialize the UI and bindings
            InitializeComponent();
            // set the item source to the list
            listView_stockItems.ItemsSource = _stockManager.StockItems;
        }

        private void BuyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // it is only possible to buy an item if it is in stock
            // and the customer has enough balance
            StockItem item = e.Parameter as StockItem;
            e.CanExecute = item.Cost <= CurrentCustomer.Balance && item.Quantity > 0;
        }

        private void BuyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            StockItem item = e.Parameter as StockItem;
            _stockManager.BuyItem(item);
        }
    }
}
