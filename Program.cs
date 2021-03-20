using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC
{
    class Program
    {
        static void Main(string[] args)
        {
            Comp comp = new Comp(new HDD(1, "HDD"), new Monitor());
            comp.AddDisk(new Flash(2, "Flash 240 Gb"));
            comp.PrintInfo("Monitor","Asus");
            
        }
    }
}
