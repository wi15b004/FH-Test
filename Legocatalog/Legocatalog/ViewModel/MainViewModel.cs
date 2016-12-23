using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Legocatalog.ViewModel
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
        public ObservableCollection<LegoItem> Items { get; set; }

        public LegoItem CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value;
                RaisePropertyChanged();
            }
        }

        private LegoItem currentItem;

        public MainViewModel()
        {
            Items = new ObservableCollection<LegoItem>();
            GenerateDemoData();
        }

        private void GenerateDemoData()
        {
            Items.Add(new LegoItem("Todesstern", 5000, 45321, new BitmapImage(new Uri("images/todesstern.jpg", UriKind.Relative)), "25-99"));
            Items.Add(new LegoItem("Sternenzerstoerer", 7500, 45481, new BitmapImage(new Uri("images/sternenzerstoerer.jpg", UriKind.Relative)), "20-99"));
            Items.Add(new LegoItem("Millenium Falcon", 3300, 47421, new BitmapImage(new Uri("images/millenium_falcon.jpg", UriKind.Relative)), "15-99"));
        }
    }
}