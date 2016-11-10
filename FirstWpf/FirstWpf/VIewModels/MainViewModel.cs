using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpf.VIewModels
{
    public class MainViewModel
    {
        private double price=100;
        private string title = "DemoTitle";
        private int amount;

        #region PROPERTIES
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        #endregion 

        public MainViewModel()
        {
            
        }
    }
}
