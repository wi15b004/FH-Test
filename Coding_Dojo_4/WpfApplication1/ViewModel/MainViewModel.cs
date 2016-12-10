using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using DataProvider;
using System;

namespace WpfApplication1.ViewModel
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
        /// 

        public RelayCommand AddBtnCmd { get; set; }
        public RelayCommand LoadBtnCmd { get; set; }
        public RelayCommand SaveBtnCmd { get; set; }

        private ObservableCollection<PersonVM> persons = new ObservableCollection<PersonVM>();

        public DataHandler dh { get; set; }

        private string newFirstname = "";
        private string newLastname = "";
        private int newSsn;
        private DateTime newBirthdate;// = new DateTime();

        #region Properties

        public string NewFirstname
        {
            get
            {
                return newFirstname;
            }

            set
            {
                newFirstname = value;
            }
        }

        public string NewLastname
        {
            get
            {
                return newLastname;
            }

            set
            {
                newLastname = value;
            }
        }

        public int NewSsn
        {
            get
            {
                return newSsn;
            }

            set
            {
                newSsn = value;
            }
        }

        public DateTime NewBirthdate
        {
            get
            {
                return newBirthdate;
            }

            set
            {
                newBirthdate = value;
            }
        }

        public ObservableCollection<PersonVM> Persons
        {
            get
            {
                return persons;
            }

            set
            {
                persons = value;
            }
        }

        public PersonVM Person { get; set; }

        #endregion

        public MainViewModel()
        {
            dh = new DataHandler("");

            AddBtnCmd = new RelayCommand(AddBtnClicked, () => { return true; });
            SaveBtnCmd = new RelayCommand(SaveBtnClicked, () => { return true; });
            LoadBtnCmd = new RelayCommand(LoadBtnClicked, () => { return dh.CheckIfFileExists(); });
        }

        private void AddBtnClicked()
        {
            Persons.Add(new PersonVM(NewFirstname, NewLastname, NewSsn, NewBirthdate));
        }

        private void SaveBtnClicked()
        {
            dh.Delete();
            foreach (var item in persons)
            {
                dh.Save(item.GetPerson());
            }
        }

        private void LoadBtnClicked()
        {
            Persons.Clear();
            foreach (var item in dh.Load())
            {
                Persons.Add(new PersonVM(item.Firstname, item.Lastname, item.Ssn, item.Birthdate));
            }
        }
    }
}