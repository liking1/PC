using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC
{
    class Comp
    {
        private int countDisk;
        private int countPrintDevice;
        List<Disk> disks = new List<Disk>();
        private List<IPrintInformation> printDevices = new List<IPrintInformation>();

        public void AddDeviceByIndex(int index, IPrintInformation si)
        {
            if(si == null)
            {
                throw new Exception("");
            }
            if (index < 0 || index >= printDevices.Count)
            {
                throw new Exception("");
            }
            printDevices.Insert(index, si);
            ++countPrintDevice;
        }
        public void AddDiskByIndex(int index, Disk d)
        {
            if (d == null)
            {
                throw new Exception("");
            }
            if (index < 0 || index >= disks.Count)
            {
                throw new Exception("");
            }
            disks.Insert(index, d);
            ++countDisk;
        }
        public void AddDevice(IPrintInformation ip)
        {
            if (ip != null)
            {
                printDevices.Add(ip);
            }
        }
        public void AddDisk(Disk disk)
        {
            if (disk != null)
            {
                disks.Add(disk);
            }
        }
        public bool CheckDisk(string device)
        {
            var dev = disks.Find(e => e.GetName() == device);
            if (dev != null)
            {
                return true;
            }
            return false;
        }
        public void InsertReject(string device, bool b)
        {
            var it = disks.Find(e => e.GetName() == device);
            if (it == null)
            {
                Console.WriteLine("Disk didn't enter");
                return;
            }
            if (!(it is IRemoveableDisk))
            {
                Console.WriteLine("Device isn`t removable");
                return;
            }
            IRemoveableDisk irDisk = it as IRemoveableDisk;
            if (b == true)
            {
                irDisk.Insert();
            }
            else
            {
                irDisk.Reject();
            }
        }
        public bool PrintInfo( string device, string text)
        {
            var it = printDevices.Find(e => e.GetName() == device);
            if (it == null)
            {
                Console.WriteLine("");
                return false;
            }
            if (!(it is Monitor))
            {
                Console.WriteLine("It's not Monitor, it's Printer");
                return false;
            }
            it.Print(text);
            return true;
        }
        public string ReadInfo(string device)
        {
            var it = disks.Find(e => e.GetName() == device);
            if (it != null)
            {
                Console.WriteLine("ReadInfo(Bad device)");
                return String.Empty;
            }
            return it.Memory;
        }
        public void ShowDisk()
        {
            foreach (var item in disks)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowPrintDevice()
        {
            foreach (var item in printDevices)
            {
                Console.WriteLine($"Print device: {item.GetName()}");
            }
        }
        public bool WriteInfo(string text, string showDevice)
        {
            var dev = printDevices.Find(e => e.GetName() == showDevice);
            if (dev != null)
            {
                return false;
            }
            if (dev is Printer)
            {
                Console.WriteLine("It's not Printer, it's Monitor");
                return false;
            }
            dev.Print(text);
            return true;
        }
        public Comp(Disk d, IPrintInformation pd)
        {
            AddDisk(d);
            AddDevice(pd);
        }
    }
    interface IPrintInformation
    {
        string GetName();
        void Print(string str);
    }
    class Printer : IPrintInformation
    {
        public string GetName()
        {
            return this.GetType().Name;
        }

        public void Print(string str)
        {
            Console.WriteLine($"Printer : {str}");
        }
    }
    class Monitor : IPrintInformation
    {
        public string GetName()
        {
            return this.GetType().Name;
        }

        public void Print(string str)
        {
            Console.WriteLine($"Monitor : {str}");
        }
    }

}
