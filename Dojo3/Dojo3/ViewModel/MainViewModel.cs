using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using Dojo3.Converters;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    class MainViewModel : BaseViewModel
    {
        private SampleManager manager = new SampleManager(); 
        private const string showAll = "show All";
        private ObservableCollection<StockEntryViewModel> items = new ObservableCollection<StockEntryViewModel>();
        private ObservableCollection<StockEntryViewModel> filteredItems = new ObservableCollection<StockEntryViewModel>();
        private ObservableCollection<String> unfilteredItemNames = new ObservableCollection<String>();
        private string filter;
        private RelayCommand filterBtnClickedCommand;
        private RelayCommand delteBtnClickedCommand;
        private StockEntryViewModel selectedItem;

        public string Filter
        {
            get { return filter; }
            set { filter = value; OnChange("Filter"); }
        }

        public RelayCommand DelteBtnClickedCommand
        {
            get { return delteBtnClickedCommand; }
            set { delteBtnClickedCommand = value; }
        }

        public RelayCommand FilterBtnClickedCommand
        {
            get { return filterBtnClickedCommand; }
            set { filterBtnClickedCommand = value; }
        }

        public Array Currencies
        {
            get {  return Enum.GetValues(typeof(Currencies));}
        }

        public ObservableCollection<String> UnfilteredItemNames
        {
            get { return unfilteredItemNames; }
            set { unfilteredItemNames = value; }
        }

        public ObservableCollection<StockEntryViewModel> UnfilteredItems
        {
            get { return items; }
            set { items = value; }
        }

        public ObservableCollection<StockEntryViewModel> FilteredItems
        {
            get { return filteredItems; }
            set { filteredItems = value; }
        }

       // public Currencies SelectedCurrrency
       // {
       //     get { return SelectedCurrrency; }
       //     set {
       //         SelectedCurrrency = value;
       //         OnChange("SelectedCurrency");
       //         StartConvertion();
       //     }  
       //}

       // private void StartConvertion()
       // {
       //     foreach (var item in Items)
       //     {
       //         item.CalculateSalesPriceFromEuro(SelectedCurrrency);
       //     }
       // }

        public MainViewModel()
        {
            UnfilteredItemNames.Add(showAll);
            LoadData();
            filter = showAll;
            FilterData(); 
            DelteBtnClickedCommand = new RelayCommand(DelteItem);
            FilterBtnClickedCommand = new RelayCommand(FilterData);

        }

        private void DelteItem()
        {
            DeleteData(selectedItem);
            UnfilteredItems.Remove(selectedItem);
        }

        private void FilterData()
        {
            FilteredItems.Clear();
            foreach (var item in UnfilteredItems)
            {
                if (item.Name.Equals(Filter) || Filter.Equals(showAll))
                {
                    FilteredItems.Add(item);
                }
            }
        }

        private void LoadData()
        {
            foreach (var item in manager.CurrentStock.OnStock)
            {
                UnfilteredItems.Add(new StockEntryViewModel(item)); 
                UnfilteredItemNames.Add(item.SoftwarePackage.Name);
            }
        }

        private void DeleteData(StockEntryViewModel toDelete)
        {
            foreach (var item in manager.CurrentStock.OnStock)
            {
                if (item.SoftwarePackage.Name.Equals(toDelete.Name) && item.SoftwarePackage.Category.Name.Equals(toDelete.Category))
                {
                    manager.CurrentStock.OnStock.Remove(item);
                    break;
                }
            }
        }
    }
}