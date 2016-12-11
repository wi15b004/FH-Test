using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using DataProvider;
using System;
using System.Globalization;

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

        private RelayCommand AddBtnCommand { get; set; }
        private RelayCommand LoadBtnCommand { get; set; }
        private RelayCommand SaveBtnCommand { get; set; }

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

            AddBtnCommand = new RelayCommand(AddBtnCmd, () => { return NewLastname.Length > 2; }); //return true;
            SaveBtnCommand = new RelayCommand(SaveBtnCmd, () => { return Persons.Count > 0; }); //return true;
            LoadBtnCommand = new RelayCommand(LoadBtnCmd, () => { return dh.CheckIfFileExists(); }); //return true;
        }

        private void AddBtnCmd()
        {
            Persons.Add(new PersonVM(NewFirstname, NewLastname, NewSsn, NewBirthdate));
        }

        private void SaveBtnCmd()
        {
            dh.Delete();
            foreach (var item in persons)
            {
                dh.Save(item.GetPerson());
            }
        }

        private void LoadBtnCmd()
        {
            Persons.Clear();
            foreach (var item in dh.Load())
            {
                Persons.Add(new PersonVM(item.Firstname, item.Lastname, item.Ssn, item.Birthdate));
            }
        }
    }
}