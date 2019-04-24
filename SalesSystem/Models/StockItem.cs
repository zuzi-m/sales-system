using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Models
{
    /// <summary>
    /// Class describing an item in stock that has a cost
    /// and a quantity in stock.
    /// Implements INotifyPropertyChanged to allow
    /// updating bindings to this object in XAML.
    /// </summary>
    public class StockItem : INotifyPropertyChanged
    {
        private string _name;
        private decimal _cost;
        private uint _quantity;

        public long Id { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
        public decimal Cost
        {
            get { return _cost; }
            set { _cost = value; NotifyPropertyChanged("Cost"); }
        }
        public uint Quantity
        {
            get { return _quantity; }
            set { _quantity = value; NotifyPropertyChanged("Quantity"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
