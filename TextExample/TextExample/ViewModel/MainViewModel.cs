using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

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
            Trucks = new ObservableCollection<TruckVm>();
            Trucks.Add(new TruckVm("W-14B", "Wien", new ObservableCollection<LoadVm>() {
                new LoadVm("LadungA",10,10),
                new LoadVm("LadungB", 130,400),
                new LoadVm("LadungC",30,10)
            }));
           
        }
    }
}