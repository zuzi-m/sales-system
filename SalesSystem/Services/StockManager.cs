using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SalesSystem.Models;

namespace SalesSystem.Services
{
    /// <summary>
    /// Service implementing the business logic of the stock
    /// system and its customer.
    /// </summary>
    public class StockManager
    {
        public ObservableCollection<StockItem> StockItems { get; }
        public Customer Customer { get; }
        public StockManager()
        {
            // Hardcoded data for now. In practice would be replaced
            // by querying into a database or something similar
            StockItems = new ObservableCollection<StockItem>()
            {
                new StockItem() {Name = "Armchair", Cost = 214, Quantity = 2},
                new StockItem() {Name = "Sofa", Cost = 899.25M, Quantity = 1},
                new StockItem() {Name = "Kitchen Table", Cost = 329, Quantity = 4},
                new StockItem() {Name = "Kitchen Chair", Cost = 78.99M, Quantity = 16},
                new StockItem() {Name = "Bed", Cost = 340.99M, Quantity = 3},
                new StockItem() {Name = "Chest of Drawers", Cost = 249, Quantity = 7},
                new StockItem() {Name = "Bookcase", Cost = 199, Quantity = 6}
            };
            Customer = new Customer() { Name = "Marek Zuzi", Balance = 1087.65M };
        }

        public void BuyItem(StockItem item)
        {
            if (item.Quantity <= 0)
            {
                throw new ArgumentException("Item Quantity must be more than 0 to buy");
            }
            if (Customer.Balance < item.Cost)
            {
                throw new ArgumentException("Customer Balance must be greater or equal to Item Cost to buy");
            }

            item.Quantity--;
            Customer.Balance -= item.Cost;
        }
    }
}
