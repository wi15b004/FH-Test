
using FirstWpf.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<ItemVM> items = new ObservableCollection<ItemVM>();

        #region PROPERTIES
        public RelayCommand AddBtnClickedCommand { get; set; }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
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

        public ObservableCollection<ItemVM> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }
        #endregion

        public MainViewModel()
        {
            AddBtnClickedCommand = new RelayCommand(new LetsDoIt(AddItems));
            LoadData();
        }

        private void AddItems()
        {
            Items.Add(new ItemVM(Title, Amount, Price));
        }

        private void LoadData()
        {
            Items.Add(new ItemVM("DemoEntry1", 10, 10.5));
            Items.Add(new ItemVM("DemoEntry2", 50, 32.45));
            Items.Add(new ItemVM("DemoEntry3", 34, 965));
        }
    }
}
