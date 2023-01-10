using System.Globalization;

namespace Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintDataFromBinaryFile("BinaryFile.bin");
        }
        private static void PrintDataFromBinaryFile(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + file;
            if (File.Exists(path)) 
            {
                DateTime date;
                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    date = DateTime.Now;
                    Console.WriteLine(br.ReadString());    
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write($"\nФайл изменен {date.ToString("M/MM HH:mm", CultureInfo.CurrentCulture)} на компьютере {Environment.OSVersion}");
                }
            }
        } 
    }
}