﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class ItemVM : ViewModelBase
    {
        public ObservableCollection<ItemVM> Items { get; set; }
        public string Description { get; set; }
        public BitmapImage Image { get; set; }
        public string AgeRecommendation { get; set; }

        public ItemVM(string des, BitmapImage ima, string rec)
        {
            Description = des;
            Image = ima;
            AgeRecommendation = rec;
        }

        public void AddItem (ItemVM item)
        {
            if(Items == null)
            {
                Items = new ObservableCollection<ItemVM>();
            }
            Items.Add(item);
        }
    }
}
