using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.CommandWpf;

namespace CodingDojo6.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        private ItemVM currentItem;
        public ObservableCollection<ItemVM> Items { get; set; }
        public ObservableCollection<ItemVM> Cart { get; set; }
        private RelayCommand<ItemVM> buyBtnCmd;

        public ItemVM CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<ItemVM> BuyBtnCommnd
        {
            get { return buyBtnCmd; }
            set { buyBtnCmd = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            Cart = new ObservableCollection<ItemVM>();
            BuyBtnCommnd = new RelayCommand<ItemVM>((t) =>
            {
                Cart.Add(t);
            }, (t) => { return true; });
            Items = new ObservableCollection<ItemVM>();
            GenerateData();
        }

        private void GenerateData()
        {
            Items.Add(new ItemVM("Lego", new BitmapImage(new Uri("Images/lego_porsche.png", UriKind.Relative)), "-"));
            Items.Add(new ItemVM("Playmobil", new BitmapImage(new Uri("Images/playmobil_auto.jpg", UriKind.Relative)), "-"));

            Items[Items.Count - 2].AddItem(new ItemVM("Bagger", new BitmapImage(new Uri("Images/lego_bagger.png", UriKind.Relative)), "10"));
            Items[Items.Count - 2].AddItem(new ItemVM("Kran", new BitmapImage(new Uri("Images/lego_kran.png", UriKind.Relative)), "12"));
            Items[Items.Count - 2].AddItem(new ItemVM("Radlader", new BitmapImage(new Uri("Images/lego_radlader.png", UriKind.Relative)), "14"));

            Items[Items.Count - 1].AddItem(new ItemVM("Bad", new BitmapImage(new Uri("Images/playmobil_bad.jpg", UriKind.Relative)), "2"));
            Items[Items.Count - 1].AddItem(new ItemVM("Camper", new BitmapImage(new Uri("Images/playmobil_camper.jpg", UriKind.Relative)), "3"));
            Items[Items.Count - 1].AddItem(new ItemVM("Spielplatz", new BitmapImage(new Uri("Images/playmobil_spielplatz.jpg", UriKind.Relative)), "4"));
        }
    }
}