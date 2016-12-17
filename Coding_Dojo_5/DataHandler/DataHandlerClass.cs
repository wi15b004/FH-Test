using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    public class DataHandler
    {
        public String[] Load(string name)
        {
            String[] temp = File.ReadAllLines(@".txt");
            return temp;
        }

        public void Save(List<string> data)
        {
            File.WriteAllLines(DateTime.Now.ToShortDateString()+" ")
        }

    }
}
