namespace DriveInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DriveInfo drive = new DriveInfo("C", 521, 124);
            Console.WriteLine(drive.TotalSpace);
            Console.WriteLine(drive.Name);
        }
    }
}