using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveInfo
{
    internal class DriveInfo
    {
        public DriveInfo(string name, double size, double freeSpace)
        {
            Name = name;
            TotalSpace = size;
            FreeSpace = freeSpace;
        }
        public string Name
        {
            get;
        }
         public double TotalSpace
        {
            get; 
        }
        public double FreeSpace
        {
            get; 
        }
    }
}
