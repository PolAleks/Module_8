using Microsoft.VisualBasic.FileIO;
using System.Linq.Expressions;

namespace DriveManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DriveInfo[] drivers = DriveInfo.GetDrives();
            //foreach (DriveInfo driver in drivers) 
            //{
            //    Console.WriteLine($"Название диска: {driver.Name}");
            //    Console.WriteLine($"Тип диска: {driver.DriveType}");
            //    if (driver.IsReady)
            //    {
            //        Console.WriteLine($"Объем диска: {driver.TotalSize}");
            //        Console.WriteLine($"Свободно {driver.TotalFreeSpace}");
            //        Console.WriteLine($"Метка: {driver.VolumeLabel}");
            //    }
            //}

            Console.WriteLine(new string('-', 50));

            GetCatalogs();

            GetCountFoldersAndFiles(@"D:\\");

            AddAdnDeleteDirectory();

            DeleteTestFolder();

            DeleteTestFolder2();

        }
        static void GetCatalogs()
        {
            string dirName = @"D:\\";
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

                DirectoryInfo newDir = new DirectoryInfo(dir.Root.ToString() + "/Новая папка");
                if (!newDir.Exists)
                {
                    newDir.Create();
                    Console.WriteLine($"Папок: {dir.GetDirectories().Length}\n" +
                                      $"Файлов: {dir.GetFiles().Length}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AddAdnDeleteDirectory()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"D:\\Тестовая папка");
                if (!dir.Exists)
                {
                    dir.Create();
                    Console.WriteLine(dir.FullName);

                    dir.Delete(true);
                }
                else throw new Exception("Такая директория уже существует!");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DeleteTestFolder()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\user\Desktop\testFolder");
                string dirBasket = @"C:\$RECYCLE.BIN\testFolder";

                if (!dir.Exists)
                {
                    dir.Create();
                    Console.WriteLine(dir.FullName);
                }

                if (dir.Exists && !Directory.Exists(dirBasket))
                    dir.MoveTo(dirBasket);
                else
                {
                    throw new Exception($"{dir.Name} - отсутствует, перемещение в" +
                                        $" корзину не может быть выполнено");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void DeleteTestFolder2()
        {
            try
            {
                string dirName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\NewFolder";
                Directory.CreateDirectory(dirName);
                Console.Write($"Move {dirName} to Recycle Bin (y/n)? ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    FileSystem.DeleteDirectory(dirName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}