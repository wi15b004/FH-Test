using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TruckTrack.ViewModel
{
    class MainViewModel
    {
        public RelayCommand StartBtnClickCmd { get; set; }
        public RelayCommand EndBtnClickCmd { get; set; }
        public RelayCommand SendBtnClickCmd { get; set; }
        public RelayCommand ClearBtnCmd { get; set; }

        public RelayCommand SaveBtnCmd { get; set; }

        public DispatcherTimer MyTimer { get; set; }

        public ObservableCollection<TruckVM> ReadyTrucks { get; set; }

        public ObservableCollection<TruckVM> WaitingTrucks { get; set; }

        private TruckVM selectedReadyTruck;

        public TruckVM SelectedReadyTruck
        {
            get { return selectedReadyTruck; }
            set
            {
                selectedReadyTruck = value;
                RaisePropertyChanged();
            }
        }

        public TruckVM SelectedWaitingTruck { get; set; }

        public MainViewModel()
        {
            LoadData();

            MyTimer = new DispatcherTimer();
            MyTimer.Interval = new TimeSpan(0, 0, 5);
            MyTimer.Tick += MyTimer_Tick;

            StartBtnClickCmd = new RelayCommand(AddButtonClicked, AddButtonClickedCanExecute);
            EndBtnClickCmd = new RelayCommand(EndButtonClicked, EndButtonClickedCanExecute);
            SendBtnClickCmd = new RelayCommand(SendButtonClicked, SendButtonClickedCanExecute);
            ClearBtnCmd = new RelayCommand(ClearButtonClicked, ClearButtonClickedCanExecute);
            SaveBtnCmd = new RelayCommand(SaveButtonClicked);


        }

        private void SaveButtonClicked()
        {

        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            FillData();
        }

        private bool EndButtonClickedCanExecute()
        {
            return MyTimer.IsEnabled;
        }

        private void EndButtonClicked()
        {
            MyTimer.Stop();
        }

        private bool ClearButtonClickedCanExecute()
        {
            return WaitingTrucks.Count != 0;
        }

        private void ClearButtonClicked()
        {
            WaitingTrucks.Clear();
            ReadyTrucks.Clear();
        }

        private bool SendButtonClickedCanExecute()
        {
            return true;
        }

        private void SendButtonClicked()
        {
            ReadyTrucks.Add(SelectedWaitingTruck);
            WaitingTrucks.Remove(SelectedWaitingTruck);

        }


        private bool AddButtonClickedCanExecute()
        {
            return !MyTimer.IsEnabled;
        }

        private void AddButtonClicked()
        {
            MyTimer.Start();
        }

        private void LoadData()
        {
            WaitingTrucks = new ObservableCollection<TruckVM>();
            ReadyTrucks = new ObservableCollection<TruckVM>();
        }
        public void FillData()
        {
            ObservableCollection<LoadVM> loads = new ObservableCollection<LoadVM>();

            for (int i = 0; i < 10; i++)
            {
                loads.Add(new LoadVM("a" + i, i, i));
            }


            for (int i = 0; i < 10; i++)
            {
                WaitingTrucks.Add(new TruckVM("Stadt", i, loads));

            }
        }

    }
}
