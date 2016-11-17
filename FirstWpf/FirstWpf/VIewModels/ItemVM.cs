using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpf.VIewModels
{
    public class ItemVM
    {
        private string description;
        private int amount;
        private double  price;

        public ItemVM(string description, int amount, double price)
        {
            this.description = description;
            this.amount = amount;
            this.price = price;
        }

        public double  Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
