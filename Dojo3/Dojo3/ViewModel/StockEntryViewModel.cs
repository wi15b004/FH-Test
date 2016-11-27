using CodingDojo4DataLib;
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

        private double salespriceinEuro;

        public String Name {

            get { return stockEntry.SoftwarePackage.Name; }

            set
            {

                stockEntry.SoftwarePackage.Name = value;
                OnChange("Name");

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

        public StockEntryViewModel(StockEntry entry)
        {
            stockEntry = entry;
        }

    }
}
