using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTrack.ViewModel
{
    class LoadVM
    {

        private string name;
        private int amount;
        private float weight;

        public LoadVM(string name, int amount, float weight)
        {
            this.name = name;
            this.amount = amount;
            this.weight = weight;
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
