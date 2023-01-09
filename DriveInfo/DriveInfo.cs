using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveInfo
{
    internal class Drive
    {
        public Drive(string name, double totalSpace, double freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }
        private Dictionary<string, Folder> folders = new Dictionary<string, Folder>(); 
        public void CreateFolder(string nameFolder)
        {
            folders.Add(nameFolder, new Folder(nameFolder));
            Console.WriteLine($"Папка {nameFolder} успешно создан!");
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
