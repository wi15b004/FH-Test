using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
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

        public Array Currencies
        {
            get {  return Enum.GetValues(typeof(Currencies));}
        }

        public Currencies SelectedCurrrency
        {
            get { return SelectedCurrrency; }
            set {
                SelectedCurrrency = value;
                OnChange("SelectedCurrency");
                StartConvertion();
            }  
       }

        private void StartConvertion()
        {
            foreach (var item in Items)
            {
                item.CalculateSalesPriceFromEuro(SelectedCurrrency);
            }
        }

        private List<StockEntryViewModel> stock;
        private ObservableCollection<StockEntryViewModel> items = new ObservableCollection<StockEntryViewModel>();

        public ObservableCollection<StockEntryViewModel> Items
        {
            get { return items; }
            set { items value; }
        }

        public MainViewModel()
        {
            SampleManager manager = new SampleManager();
            //stock = manager.CurrentStock.OnStock;

            foreach (var item in manager.CurrentStock.OnStock)
            {
                Items.Add(new StockEntryViewModel(item));
            }

        }
    }
}