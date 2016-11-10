using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpf.VIewModels
{
    public class ItemVm
    {
        private String description;
        private double price;
        private int amount;

        public ItemVm(string description, double price, int amount)
        {
            this.description = description;
            this.price = price;
            this.amount = amount;
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        
    }
}
