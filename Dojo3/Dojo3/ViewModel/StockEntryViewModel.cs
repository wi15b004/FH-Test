using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo3.ViewModel
{
    class StockEntryViewModel : BaseViewModel
    {

        private StockEntry stockEntry;

        private double purchasepriceiIEuro;
        private double salespriceInEuro;

        public String Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                OnChange("Name");
            }
        }

        public String Category
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                OnChange("Category");
            }
        }

        public double SalesPrice {

            get { return stockEntry.SoftwarePackage.SalesPrice;  }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                OnChange("SalesPrice");
            }    
        }

        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                OnChange("PurchasePrice");
            }
        }

        public int OnStock
        {
            get { return stockEntry.Amount; }
            set
            {
                stockEntry.Amount = value;
                OnChange("OnStock");
            }
        }

        public StockEntryViewModel()
        {
            this.stockEntry = new StockEntry();
            this.stockEntry.SoftwarePackage = new Software("");
            this.stockEntry.SoftwarePackage = new Group();
            this.stockEntry.SoftwarePackage.Name = "name";
        }

        public StockEntryViewModel(StockEntry entry)
        {
            this.stockEntry = entry;
            salespriceInEuro = entry.SoftwarePackage.SalesPrice;
            purchasepriceiIEuro = entry.SoftwarePackage.PurchasePrice;
        }

        public void CalculateSalesPriceFromEuro(Currencies currency)
        {
            this.SalesPrice = CurrencyConverter.ConvertFromEuroTo(currency, salespriceInEuro);
            this.PurchasePrice = CurrencyConverter.ConvertFromEuroTo(currency, purchasepriceiIEuro);
        }

    }
}
