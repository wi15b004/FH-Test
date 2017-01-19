using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler h = new Handler();
            while (true)
            {
                h.sendMessage("W-15b@Wien@Ladung1@10@4@Ladung2@30@1000");
                Thread.sleep(5000);
            }
        }
    }
}
