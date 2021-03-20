using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC
{
    abstract class Disk
    {
        private int memSize;
        private string memory;
        public string Memory
        {
            get => memory; 
            set => this.memory = value;
        }
        public int MemSize
        {
            get => memSize;
            set => this.memSize = value;
        }
        public virtual string GetName()
        {
            return this.GetType().Name;
        }
        public string Read()
        {
            return Memory;
        }
        public void Write(string text)
        {
            Memory += text;
            ++MemSize;
        }
        public Disk(int memSize = 0, string memory = "NoName")
        {
            Memory = memory;
            MemSize = memSize;
        }

        public override string ToString()
        {
            return $"Disk\nName:{GetName()}, Memory: {Memory}, MemorySize: {MemSize}";
        }
    }
    
    interface IDisk
    {
        string Read();
        void Write(string text);

    }
    interface IRemoveableDisk
    {
        bool HasDisk { get; }
        void Insert();
        void Reject();
    }
    class CD : Disk, IRemoveableDisk
    {
        public CD(int memSize = 0, string memory = "NoName")
            :base(memSize, memory)
        {
            
        }

        private bool hasDisk;
        public bool HasDisk { get => hasDisk; }

        public void Insert()
        {
            hasDisk = true;
        }
        public void Reject()
        {
            hasDisk = false;
        }
        public override string GetName()
        {
            return this.GetType().Name;
        }
    }
    class Flash : Disk, IRemoveableDisk
    {
        public Flash(int memSize = 0, string memory = "NoName")
            : base(memSize, memory)
        {

        }

        private bool hasDisk;
        public bool HasDisk { get => hasDisk; }

        public void Insert()
        {
            hasDisk = true;
        }
        public void Reject()
        {
            hasDisk = false;
        }
        public override string GetName()
        {
            return this.GetType().Name;
        }
    }
    class HDD : Disk
    {
        public HDD(int memSize = 0, string memory = "NoName")
            : base(memSize, memory)
        {

        }
        public override string GetName()
        {
            return this.GetType().Name;
        }
        
    }
    class DVD : Disk, IRemoveableDisk
    {
        public DVD(int memSize = 0, string memory = "NoName")
            : base(memSize, memory)
        {

        }
        private bool hasDisk;
        public bool HasDisk { get => hasDisk; }

        public void Insert()
        {
            hasDisk = true;
        }
        public void Reject()
        {
            hasDisk = false;
        }
        public override string GetName()
        {
            return this.GetType().Name;
        }
    }
}

