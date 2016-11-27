using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTrack.ViewModel
{
    class TruckVM
    {

        private string source;
        private int duration;

        public TruckVM(string source, int duration, ObservableCollection<LoadVM> loads)
        {
            this.source = source;
            this.duration = duration;
            Loads = loads;
        }

        public ObservableCollection<LoadVM> Loads { get; set; }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }


        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        public override string ToString()
        {
            return source + " " + duration;
        }


    }
}
