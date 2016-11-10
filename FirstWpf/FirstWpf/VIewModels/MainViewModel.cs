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
        private int amount=0;
        private List<ItemVm> items = new List<ItemVm> ();

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

        public int Amount
        {
            get { return amount; }
            set { amount = value;  }
        }
        #endregion 

        public MainViewModel()
        {
            AddBtnClickCommand = new RelayCommmand(new DoIt());
            LoadData();
        }

        private void LoadData()
        {

            items.Add(new ItemVm("Testeintrag", 10.5, 5));
            items.Add(new ItemVm("Testeintrag2", 15.5, 2));
            items.Add(new ItemVm("Testeintrag3", 1.5, 3));
        }


    }
}
