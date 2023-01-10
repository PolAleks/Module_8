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
                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    Console.WriteLine(br.ReadString());    
                }
            }
        } 
    }
}