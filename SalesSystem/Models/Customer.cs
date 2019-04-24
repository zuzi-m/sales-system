using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Models
{
    /// <summary>
    /// Class describing a customer of the system.
    /// Implements the INotifyPropertyChanged to allow
    /// updating bindings to this object in XAML.
    /// </summary>
    public class Customer : INotifyPropertyChanged
    {
        private string _name;
        private decimal _balance;
        public long Id { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; NotifyPropertyChanged("Balance"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
