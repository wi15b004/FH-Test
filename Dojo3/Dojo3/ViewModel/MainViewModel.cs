using GalaSoft.MvvmLight;

namespace Dojo3.ViewModel
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

        private const string showAll = "Show All";
        private List<StockEntry> stock;
        private ObservableCollection<StockEntryVm> saleitems = new ObservableCollection<StockEntryVm>(); //Vollständige Produktliste (Backup)
        private ObservableCollection<StockEntryVm> filteredSaleitems = new ObservableCollection<StockEntryVm>(); //Gefilterte Produktliste
        private string selectedSearchItem; //Auswahl Combobox
        private ObservableCollection<string> filteredList = new ObservableCollection<string>(); //Inhalt Combobox (Produktliste + ShowAll)
        private StockEntryVm selectedSalesItem; //Auswahl Datagrid
        public RelayCommand SearchBtn { get; set; }
        public RelayCommand ClearBtn { get; set; }

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}