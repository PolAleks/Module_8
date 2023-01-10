using System.Reflection;

namespace FileWriter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "/MyFirstFile.txt";

            //if (!File.Exists(filePath + fileName)) 
            //{
            //    using (StreamWriter sw = File.CreateText(filePath + fileName)) 
            //    {
            //        sw.WriteLine("Олег");
            //        sw.WriteLine("Дмитрий");
            //        sw.WriteLine("Иван");
            //    }
            //}
            GetTextFromCurrentFile(filePath + fileName);

            Console.WriteLine(new string('-',50));

            string path = @"E:\LocalRepos\Module_8\FileWriter\Program.cs";

            GetTextFromCurrentFile(path);
        }
        private static void GetTextFromCurrentFile(string nameFile)
        {
            FileInfo file = new FileInfo(nameFile);
            using (StreamWriter sw = file.AppendText()) 
            {
                sw.WriteLine("// Время запуска программы: {0}", DateTime.Now);
            }
            string str = string.Empty;
            using (StreamReader sr = File.OpenText(nameFile))
            {
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}

