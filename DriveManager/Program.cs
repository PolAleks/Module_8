using System.Linq.Expressions;

namespace DriveManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo driver in drivers) 
            {
                Console.WriteLine($"Название диска: {driver.Name}");
                Console.WriteLine($"Тип диска: {driver.DriveType}");
                if (driver.IsReady)
                {
                    Console.WriteLine($"Объем диска: {driver.TotalSize}");
                    Console.WriteLine($"Свободно {driver.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {driver.VolumeLabel}");
                }
            }

            Console.WriteLine(new string('-', 50));

            GetCatalogs();

            GetCountFoldersAndFiles(@"S://");
        }
        static void GetCatalogs()
        {
            string dirName = "D:\\";
            if (Directory.Exists(dirName)) 
            {
                Console.WriteLine("Папки:");
                string[] foldrers = Directory.GetDirectories(dirName);

                foreach (string folder in foldrers)
                {
                    Console.WriteLine(folder);
                }

                Console.WriteLine(new string('-', 50));

                Console.WriteLine("Файлы: ");
                string[] files = Directory.GetFiles(dirName);

                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }
        static void GetCountFoldersAndFiles(string directory)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(directory);
                if (dir.Exists)
                {
                    Console.WriteLine($"Папок: {dir.GetDirectories().Length}\n" +
                                      $"Файлов: {dir.GetFiles().Length}");
                }
                else 
                {
                    throw new Exception($"{directory} - такой директории нет");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}