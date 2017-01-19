using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using TextExample.Communication;
using System;

namespace TextExample.ViewModel
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

        public ObservableCollection<TruckVm> Trucks { get; set; }
        private TruckVm currentSelectedTruck;

        public TruckVm CurrentseletedTruck
        {
            get { return currentSelectedTruck; }
            set { currentSelectedTruck = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {

            if(IsInDesignMode) //wird ausgeführt wenn ned ausgeführt
            {

            }
            else // wird ausgeüfhrt wenn programmstart und ned in xaml - wenns wirklich rennt
            {
                Server server = new Server(GuiUpdate);
            }
            GenerateDemoData();
           
           
        }

        private void GuiUpdate(string obj)//MEthode wird asugeführt wenn der clienthandler was empfängt
        {
            obj = "W-15b@Wien@Ladung1@10@4@Ladung2@30@1000"; //kann selbst gestaltet wrden
            String[] unformated = obj.Split('@');

            var loads = new ObservableCollection<LoadVm>();
            for (int i = 2; i < unformated.Length; i=i+3)
            {
                loads.Add(new LoadVm(unformated[i], int.Parse(unformated[i + 1]), int.Parse(unformated[i + 2]))); //loads auslesen mit schleife weil mehrer loads pro truck
            }
            TruckVm newTruck = new TruckVm(unformated[0], unformated[1], loads); //neuen truck fühlen mit den elementen aus obj
            App.Current.Dispatcher.Invoke(() => // lanbda expressions - braucht ma weil mehrer threads die in die gui "eingreifen" - "syncht die threads und seralsierts"
            {
                Trucks.Add(newTruck);
            });
        }

        public void GenerateDemoData()
        {
            Trucks = new ObservableCollection<TruckVm>();
            Trucks.Add(new TruckVm("W-14B", "Wien", new ObservableCollection<LoadVm>() {
                new LoadVm("LadungA",10,10),
                new LoadVm("LadungB", 130,400),
                new LoadVm("LadungC",30,10)
            }));
        }

    }
}