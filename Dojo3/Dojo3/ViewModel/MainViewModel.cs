using CodingDojo4DataLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

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
        private ObservableCollection<StockEntryViewModel> saleitems = new ObservableCollection<StockEntryViewModel>(); //Vollständige Produktliste (Backup)
        private ObservableCollection<StockEntryViewModel> filteredSaleitems = new ObservableCollection<StockEntryViewModel>(); //Gefilterte Produktliste
        private string selectedSearchItem; //Auswahl Combobox
        private ObservableCollection<string> filteredList = new ObservableCollection<string>(); //Inhalt Combobox (Produktliste + ShowAll)
        private StockEntryViewModel selectedSalesItem; //Auswahl Datagrid
        public RelayCommand SearchBtn { get; set; }
        public RelayCommand ClearBtn { get; set; }

        #region Properties
        public ObservableCollection<string> FilteredList
        {
            get { return filteredList; }
            set
            {
                filteredList = value;
            }
        }

        public ObservableCollection<StockEntryViewModel> Saleitems
        {
            get { return saleitems; }
            set { saleitems = value; }
        }

        public ObservableCollection<StockEntryViewModel> FilteredSaleitems
        {
            get { return filteredSaleitems; }
            set { filteredSaleitems = value; }
        }

        public string SelectedSearchItem
        {
            get
            {
                return selectedSearchItem;
            }
            set
            {
                selectedSearchItem = value;
                RaisePropertyChanged();
            }
        }

        public StockEntryViewModel SelectedSalesItem
        {
            get
            {
                return selectedSalesItem;
            }

            set
            {
                selectedSalesItem = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public MainViewModel()
        {
            LoadData();
            SearchBtn = new RelayCommand(SearchBtnClicked);
            ClearBtn = new RelayCommand(ClearBtnClicked);
        }

        public void LoadData()
        {
            SampleManager manager = new SampleManager();
            stock = manager.CurrentStock.OnStock;
            filteredList.Add(showAll);

            foreach (var item in manager.CurrentStock.OnStock)
            {
                saleitems.Add(new StockEntryViewModel(item));
                filteredSaleitems.Add(new StockEntryViewModel(item));
                filteredList.Add(new StockEntryViewModel(item).Name);
            }
        }

        private void ClearBtnClicked()
        {
            DeleteData(SelectedSalesItem);
        }


        private void SearchBtnClicked()
        {
            FilterData(selectedSearchItem);
        }

        private void FilterData(string selection)
        {
            FilteredSaleitems.Clear();
            foreach (var item in Saleitems)
            {
                if (item.Name.Equals(selection) || selection == showAll)
                {
                    FilteredSaleitems.Add(item);
                }
            }
        }

        private void DeleteData(StockEntryViewModel selection)
        {
            FilteredSaleitems.Remove(selection);
            Saleitems.Remove(selection);
            FilteredList.Clear();
            FilteredList.Add(showAll);
            foreach (var item in Saleitems)
            {
                FilteredList.Add(item.Name);
            }
        }

    }
}