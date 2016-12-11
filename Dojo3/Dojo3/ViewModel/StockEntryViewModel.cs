using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo3.ViewModel
{
    class StockEntryViewModel : ViewModelBase
    {

        private StockEntry stockEntry;
        //private double purchasepriceiIEuro;
        private double salespriceInEuro;

        public int Stock
        {
            get { return stockEntry.Amount; }
            set { stockEntry.Amount = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                RaisePropertyChanged();
            }
        }

        public string category
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                RaisePropertyChanged();
            }
        }

        public double SalesPrice
        {
            get { return stockEntry.SoftwarePackage.SalesPrice; }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                RaisePropertyChanged();
            }
        }
        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                RaisePropertyChanged();
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public StockEntryViewModel(StockEntry entry)
        {
            stockEntry = entry;
            salespriceInEuro = entry.SoftwarePackage.SalesPrice;
        }

        public StockEntryViewModel()

        {
            stockEntry = new StockEntry();
            stockEntry.SoftwarePackage = new Software("");
            stockEntry.SoftwarePackage.Category = new Group();
            stockEntry.SoftwarePackage.Category.Name = "dummy";
        }
    }
}
