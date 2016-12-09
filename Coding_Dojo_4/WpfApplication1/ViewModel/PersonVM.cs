using DataProvider.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    public class PersonVM : ViewModelBase
    {
        private Person per;

        public string Firstname
        {
            get { return per.Firstname; }
            set
            {
                per.Firstname = value;
                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get { return per.Lastname; }
            set
            {
                per.Lastname = value;
                RaisePropertyChanged();
            }
        }

        public int Ssn
        {
            get { return per.Ssn; }
            set
            {
                per.Ssn = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Birthdate
        {
            get { return per.Birthdate; }
            set
            {
                per.Birthdate = value;
                RaisePropertyChanged();
            }
        }

        public PersonVM(string firstname, string lastname, int ssn, DateTime birthdate)
        {
            per = new Person(firstname, lastname, ssn, birthdate);
        }

        public Person GetPerson()
        {
            return per;
        }

    }
}
