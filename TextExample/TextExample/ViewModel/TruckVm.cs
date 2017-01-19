using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextExample.ViewModel
{
    public class TruckVm : ViewModelBase
    {

        public String Id { get; set; }

        public String Source { get; set; }

        public ObservableCollection<LoadVm> Loads { get; set; }

        public int TotalWeight
        {
            get
            {
                int temp = 0;
                foreach (var item in Loads)
                {
                    temp += item.Weight * item.Amount;
                }
                return temp;
            }
        }

        public TruckVm(string id, string source, ObservableCollection<LoadVm> loads)
        {
            Id = id;
            Source = source;
            Loads = loads;
        }

    }
}
