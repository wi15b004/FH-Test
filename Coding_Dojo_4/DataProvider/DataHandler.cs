using DataProvider.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class DataHandler
    {

        private string path;
        private const string fn = @"Persons.csv";

        public DataHandler(string path)
        {
            this.path = path;
        }

        public List<Person> Load()
        {
            List<Person> temp = new List<Person>();
            string[] lines = File.ReadAllLines(path + fn);
            foreach (var item in lines)
            {
                var val = item.Split(';');
                temp.Add(new Person(val[0], val[1], int.Parse(val[2]), DateTime.ParseExact(val[3], "dd.MM.yyyy hh:mm:ss", CultureInfo.InvariantCulture)));
            }
            return temp;
        }

        public void Save(Person per)
        {
            File.AppendAllText(path + fn, String.Format("{0};{1};{2};{3}\r\n", per.Firstname, per.Lastname, per.Ssn, per.Birthdate));
        }

        public void Delete()
        {
            if (CheckIfFileExists())
            {
                File.Delete(path + fn);
            }
        }

        public bool CheckIfFileExists()
        {
            return File.Exists(path + fn);
        }

    }
}
